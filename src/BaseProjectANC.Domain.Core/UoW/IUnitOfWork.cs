using BaseProjectANC.Domain.Core.Commands;

namespace BaseProjectANC.Domain.Core.UoW
{
    public interface IUnitOfWork
    {
        CommandResponse Commit();
    }
}
