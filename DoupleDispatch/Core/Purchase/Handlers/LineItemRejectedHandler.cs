using DoupleDispatch.Core.Purchase.Common;
using DoupleDispatch.Core.Purchase.Contracts;
using DoupleDispatch.Core.Purchase.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoupleDispatch.Core.Purchase.Handlers
{
    public class LineItemRejectedHandler : IEventHandler<LineItemRejected>
    {
        public LineItemRejectedHandler()
        {
        }

        public Task Handle(LineItemRejected notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Item {notification.LineItemId} with ${notification.Cost} couldn't added becasuse it exceeded the limit");
            return Task.CompletedTask;
        }
    }
}
