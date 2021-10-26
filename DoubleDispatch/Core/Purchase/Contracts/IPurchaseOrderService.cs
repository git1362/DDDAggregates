using DoubleDispatch.Core.Purchase.Aggregates;

namespace DoubleDispatch.Core.Purchase.Contracts
{
    public interface IPurchaseOrderService
    {
        bool WouldAddBeUnderLimit(PurchaseOrder order, LineItem newItem);
        bool WouldUpdateBeUnderLimit(long purchaseOrderId, LineItem existingItem, decimal newCost);
    }
}
