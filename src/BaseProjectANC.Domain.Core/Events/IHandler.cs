namespace BaseProjectANC.Domain.Core.Events
{
    public interface IHandler<in T> where T : Message
    {
        void Handler(T message);
    }
}
