using MediatR;
using System.Threading.Tasks;
using DoubleDispatch.Core.Purchase.Common;
using DoubleDispatch.Core.Purchase.Contracts;

namespace DoubleDispatch.Infrastrcuture
{
    public class MediatrBus : IBus
    {
        private readonly IMediator _mediator;

        public MediatrBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Dispatch<TEvent>(TEvent e) where TEvent : IDomainEvent
        {
            await _mediator.Publish(e);
        }
    }
}
