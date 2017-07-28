using BaseProjectANC.Domain.Core.UoW;
using BaseProjectANC.Domain.Core.Commands;
using BaseProjectANC.Infra.Data.Context;

namespace BaseProjectANC.Infra.Data.IoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextSQLS _context;

        public UnitOfWork(ContextSQLS context)
        {
            this._context = context;
        }

        public CommandResponse Commit()
        {
            var result = _context.SaveChanges();
            return new CommandResponse(result > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
