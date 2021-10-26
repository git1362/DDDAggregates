using DoubleDispatch.Core.Purchase.Common;
using System.Threading.Tasks;

namespace DoubleDispatch.Core.Purchase.Contracts
{
    public interface IBus
    {
        Task Dispatch<TEvent>(TEvent e) where TEvent : IDomainEvent;
    }
}
