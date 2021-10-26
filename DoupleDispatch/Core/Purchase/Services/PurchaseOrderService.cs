using System.Linq;
using DoupleDispatch.Core.Purchase.Aggregates;
using DoupleDispatch.Core.Purchase.Contracts;


namespace DoupleDispatch.Core.Purchase.Services
{
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IPurchaseOrderRepository _purchaseOrderRepository;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
        }
        public bool WouldAddBeUnderLimit(PurchaseOrder order, LineItem newItem)
        {
            return order.Items.Sum(i => i.Cost) + newItem.Cost <= order.SpendLimit;
        }

        public bool WouldUpdateBeUnderLimit(long purchaseOrderId, LineItem existingItem, decimal newCost)
        {
            var po = _purchaseOrderRepository.GetById(purchaseOrderId);
            // check for null, check if item belongs to PO
            return po.Items.Sum(i => i.Cost) + (newCost - existingItem.Cost) <= po.SpendLimit;
        }
    }
}
