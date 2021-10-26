using DoubleDispatch.Core.Purchase.Aggregates;

namespace DoubleDispatch.Core.Purchase.Contracts
{
    public interface IPurchaseOrderRepository
    {
        void Add(PurchaseOrder purchaseOrder);
        PurchaseOrder GetById(long id);
    }
}
