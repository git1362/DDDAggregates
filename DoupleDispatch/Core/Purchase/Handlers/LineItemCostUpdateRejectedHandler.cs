using DoupleDispatch.Core.Purchase.Common;
using DoupleDispatch.Core.Purchase.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoupleDispatch.Core.Purchase.Handlers
{
    public class LineItemCostUpdateRejectedHandler : IEventHandler<LineItemCostUpdateRejected>
    {
        public LineItemCostUpdateRejectedHandler()
        {
        }

        public Task Handle(LineItemCostUpdateRejected notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Item {notification.LineItemId} with ${notification.Cost} couldn't updated successfully becasuse it exceeded the limit.");
            return Task.CompletedTask;
        }
    }
}
