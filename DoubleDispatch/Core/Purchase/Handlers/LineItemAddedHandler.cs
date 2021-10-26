using DoubleDispatch.Core.Purchase.Common;
using DoubleDispatch.Core.Purchase.Contracts;
using DoubleDispatch.Core.Purchase.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoubleDispatch.Core.Purchase.Handlers
{
    public class LineItemAddedHandler : IEventHandler<LineItemAdded>
    {
        public LineItemAddedHandler()
        {
        }

        public Task Handle(LineItemAdded notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Item {notification.LineItemId} with ${notification.Cost} has been added to puchase Items Successfully.");
            return Task.CompletedTask;
        }
    }
}
