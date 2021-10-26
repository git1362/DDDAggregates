using MediatR;
using System.Threading.Tasks;
using DoupleDispatch.Core.Purchase.Common;
using DoupleDispatch.Core.Purchase.Contracts;

namespace DoupleDispatch.Infrastrcuture
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
