using BaseProjectANC.Domain.Core.Commands;
using BaseProjectANC.Domain.Core.Events;

namespace BaseProjectANC.Domain.Core.Bus
{
    public interface IBus
    {
        void RaizeEvent<T>(T theEvent) where T : Event;

        void SendCommand<T>(T theCommand) where T : Command;
    }
}
