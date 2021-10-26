using System.Linq;
using DoupleDispatch.Core.Purchase.Common;
using DoupleDispatch.Core.Purchase.Contracts;
using DoupleDispatch.Core.Purchase.Events;
using System.Collections.Generic;
using System;

namespace DoupleDispatch.Core.Purchase.Aggregates
{
    public class PurchaseOrder: AggregateRoot
    {
        private List<LineItem> _items { get; } = new List<LineItem>();
        public IReadOnlyCollection<LineItem> Items => _items.ToList();

        public decimal SpendLimit { get; set; }


        protected PurchaseOrder()
        {

        }

        private PurchaseOrder(decimal spendLimit)
        {
            Id = new Random().Next(1, 30);
            SpendLimit = spendLimit;
        }

        public static PurchaseOrder CreatePurchase(decimal spendLimit)
        {
            return new PurchaseOrder(spendLimit);
        }

        public bool CheckLimit(LineItem item, decimal newValue)
        {
            var currentSum = Items.Sum(i => i.Cost);
            decimal difference = newValue - item.Cost;

            return currentSum + difference <= SpendLimit;
        }

        public bool CheckLimit(LineItem newItem)
        {
            return Items.Sum(i => i.Cost) + newItem.Cost <= SpendLimit;
        }

        public void TryAddItem(LineItem item, IPurchaseOrderService poService)
        {
            if (poService.WouldAddBeUnderLimit(this, item))
            {
                _items.Add(item);
                AddDomainEvent(new LineItemAdded { LineItemId = item.Id, Cost = item.Cost });
            }
            else
            {
                AddDomainEvent(new LineItemRejected { LineItemId = item.Id, Cost = item.Cost });
            }
        }

        public void TryUpdateCost(decimal cost, long lineItemId,  IPurchaseOrderService poService)
        {
            var existingLineItem = Items.Where(lineItem => lineItem.Id == lineItemId).SingleOrDefault();
            var index = Items.ToList().FindIndex(existingLineItem => existingLineItem.Id == lineItemId);

            if (poService.WouldUpdateBeUnderLimit(Id, existingLineItem, cost))
            {
                existingLineItem.UpdateCost(cost);
                AddDomainEvent(new LineItemCostUpdated { LineItemId = lineItemId, Cost = cost });
                Items.ToList().RemoveAt(index);
                Items.ToList().Add(existingLineItem);
            }
            else
            {
                AddDomainEvent(new LineItemCostUpdateRejected { LineItemId = lineItemId, Cost = cost });
            }
        }
    }
}
