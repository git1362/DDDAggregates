using DoupleDispatch.Core.Purchase.Common;
using DoupleDispatch.Core.Purchase.Contracts;
using DoupleDispatch.Core.Purchase.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DoupleDispatch.Core.Purchase.Handlers
{
    public class LineItemCostUpdatedHandler :IEventHandler<LineItemCostUpdated>
    {
        public LineItemCostUpdatedHandler()
        {
        }

        public Task Handle(LineItemCostUpdated notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Item {notification.LineItemId} with ${notification.Cost} has been updated successfully.");

            return Task.CompletedTask;
        }
    }
}
