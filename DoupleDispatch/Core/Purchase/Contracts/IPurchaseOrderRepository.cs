using DoupleDispatch.Core.Purchase.Aggregates;

namespace DoupleDispatch.Core.Purchase.Contracts
{
    public interface IPurchaseOrderRepository
    {
        void Add(PurchaseOrder purchaseOrder);
        PurchaseOrder GetById(long id);
    }
}
