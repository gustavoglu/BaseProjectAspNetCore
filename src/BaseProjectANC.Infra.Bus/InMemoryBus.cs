using BaseProjectANC.Domain.Core.Bus;
using System;
using BaseProjectANC.Domain.Core.Commands;
using BaseProjectANC.Domain.Core.Events;
using BaseProjectANC.Domain.Core.Notifications;

namespace BaseProjectANC.Infra.Bus
{
    public class InMemoryBus : IBus
    {
        public static Func<IServiceProvider> ContainerAccessor { get; set; }
        public static IServiceProvider Container => ContainerAccessor();

        public void RaizeEvent<T>(T theEvent) where T : Event
        {
            Publish(theEvent);
        }

        public void SendCommand<T>(T theCommand) where T : Command
        {
            Publish(theCommand);
        }

        private static void Publish<T>(T message) where T : Message
        {
            var type = message.MessageType.Equals("DomainNotification") ? 
                typeof(IDomainNotificationHandler<T>) : 
                typeof(IHandler<T>);

            var obj = Container.GetService(type);

            ((IHandler<T>)obj).Handler(message);

        }

        private object GetService(Type serviceType)
        {
            return Container.GetService(serviceType);
        }
        
        private T GetService<T>()
        {
            return (T)Container.GetService(typeof(T));
        }
    }
}
