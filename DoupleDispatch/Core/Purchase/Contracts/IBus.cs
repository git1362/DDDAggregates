using DoupleDispatch.Core.Purchase.Common;
using System.Threading.Tasks;

namespace DoupleDispatch.Core.Purchase.Contracts
{
    public interface IBus
    {
        Task Dispatch<TEvent>(TEvent e) where TEvent : IDomainEvent;
    }
}
