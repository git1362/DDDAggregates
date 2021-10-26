using DoupleDispatch.Core.Purchase.Common;
using DoupleDispatch.Core.Purchase.Contracts;
using System;

namespace DoupleDispatch.Core.Purchase.Aggregates
{
    public class LineItem: Entity
    {
        public long PurchaseOrderId { get; private set; } // avoid having circular reference between aggregate and children

        protected LineItem() { }

        private LineItem(long purchaseOrderId, decimal cost)
        {
            Id = new Random().Next(1, 30);
            PurchaseOrderId = purchaseOrderId;
            Cost = cost;
        }

        public static LineItem CreateLineItem(long purchaseOrderId, decimal cost)
        {
            return new LineItem(purchaseOrderId, cost);
        }

        public void UpdateCost(decimal cost)
        {
            Cost = cost;
        }

        public decimal Cost { get; private set; }
    }
}
