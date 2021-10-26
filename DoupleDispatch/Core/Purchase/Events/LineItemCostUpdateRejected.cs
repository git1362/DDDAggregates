using DoupleDispatch.Core.Purchase.Common;

namespace DoupleDispatch.Core.Purchase.Events
{
    public class LineItemCostUpdateRejected: IDomainEvent
    {
        public long LineItemId { get; set; }
        public decimal Cost { get; set; }
    }
}
