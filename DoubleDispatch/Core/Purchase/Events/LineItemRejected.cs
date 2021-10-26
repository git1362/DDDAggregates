using DoubleDispatch.Core.Purchase.Common;

namespace DoubleDispatch.Core.Purchase.Events
{
    public class LineItemRejected : IDomainEvent
    {
        public long LineItemId { get; set; }
        public decimal Cost { get; set; }
    }
}
