using DoupleDispatch.Core.Purchase.Common;

namespace DoupleDispatch.Core.Purchase.Events
{
    public class LineItemAdded: IDomainEvent
    {
        public long LineItemId { get; set; }
        public decimal Cost { get; set; }
    }
}
