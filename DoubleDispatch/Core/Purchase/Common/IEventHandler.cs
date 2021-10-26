using MediatR;

namespace DoubleDispatch.Core.Purchase.Common
{
    public interface IEventHandler<in TEvent>: INotificationHandler<TEvent> where TEvent: INotification
    {
    }
}
