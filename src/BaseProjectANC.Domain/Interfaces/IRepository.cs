using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BaseProjectANC.Domain.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        void Criar(T entity);

        void Criar(List<T> entitys);

        void Atualizar(T entity);

        void Deletar(Guid id);

        void Reativar(Guid id);

        IEnumerable<T> Pesquisar(Expression<Func<T,bool>> predicado);

        IEnumerable<T> TrazerTodos();

        IEnumerable<T> TrazerTodosAtivos();

        IEnumerable<T> TrazerTodosDeletados();

        T TrazerPorId(Guid id);

        T TrazerAtivoPorId(Guid id);

        T TrazerDeletadoPorId(Guid id);
    }
}
