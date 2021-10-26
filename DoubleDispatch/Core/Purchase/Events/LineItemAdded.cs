using DoubleDispatch.Core.Purchase.Common;

namespace DoubleDispatch.Core.Purchase.Events
{
    public class LineItemAdded: IDomainEvent
    {
        public long LineItemId { get; set; }
        public decimal Cost { get; set; }
    }
}
