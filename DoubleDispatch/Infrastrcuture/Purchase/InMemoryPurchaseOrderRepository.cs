using DoubleDispatch.Core.Purchase.Aggregates;
using DoubleDispatch.Core.Purchase.Contracts;
using System.Collections.Generic;

namespace DoubleDispatch.Infrastrcuture.Purchase
{
    public class InMemoryPurchaseOrderRepository : IPurchaseOrderRepository
    {
        private Dictionary<long, PurchaseOrder> _collection = new Dictionary<long, PurchaseOrder>();

        public void Add(PurchaseOrder purchaseOrder)
        {
            if (!_collection.ContainsKey(purchaseOrder.Id))
            {
                _collection.Add(purchaseOrder.Id, purchaseOrder);
            }
        }

        public PurchaseOrder GetById(long id)
        {
            if (!_collection.ContainsKey(id)) return null;
            return _collection[id];
        }
    }
}
