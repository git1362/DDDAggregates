using DoubleDispatch.Core.Purchase.Common;

namespace DoubleDispatch.Core.Purchase.Events
{
    public class LineItemCostUpdateRejected: IDomainEvent
    {
        public long LineItemId { get; set; }
        public decimal Cost { get; set; }
    }
}
