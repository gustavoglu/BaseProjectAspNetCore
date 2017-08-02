using BaseProjectANC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BaseProjectANC.Domain.Core.Models;
using BaseProjectANC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BaseProjectANC.Infra.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected ContextSQLS Db;

        protected DbSet<T> DbSet;

        public Repository(ContextSQLS db)
        {
            this.Db = db;
            this.DbSet = Db.Set<T>();
        }

        public virtual void Atualizar(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Criar(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Criar(List<T> entitys)
        {
            foreach (var entity in entitys)
            {
                DbSet.Add(entity);
            }
        }

        public virtual void Deletar(Guid id)
        {
            var entity = DbSet.Find(id);
            entity.Deletado = true;
            DbSet.Remove(entity);
        }

        public virtual IEnumerable<T> Pesquisar(Expression<Func<T, bool>> predicado)
        {
           return DbSet.Where(predicado);
        }

        public virtual void Reativar(Guid id)
        {
            var entity = DbSet.Find(id);
            entity.Deletado = false;
            Atualizar(entity);
        }

        public virtual T TrazerAtivoPorId(Guid id)
        {
            return DbSet.FirstOrDefault(e => e.Id == id && e.Deletado == false);
        }

        public virtual T TrazerDeletadoPorId(Guid id)
        {
            return DbSet.FirstOrDefault(e => e.Id == id && e.Deletado == true);
        }

        public virtual T TrazerPorId(Guid id)
        {
            return DbSet.FirstOrDefault(e => e.Id == id);
        }

        public virtual IEnumerable<T> TrazerTodos()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<T> TrazerTodosAtivos()
        {
            return DbSet.Where(e => e.Deletado == false).ToList();
        }

        public virtual IEnumerable<T> TrazerTodosDeletados()
        {
            return DbSet.Where(e => e.Deletado == true).ToList();
        }
        public virtual void Dispose()
        {
           this.Db.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
