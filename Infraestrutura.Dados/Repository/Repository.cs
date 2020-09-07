using Dominio.Aggregates;
using Dominio.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infraestrutura.Dados.Repository
{

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        public readonly IQueryableUnitOfWork UnitOfWork;

        protected Repository()
        {
            if (unitOfWork == null)
                throw new ArgumentNullException("unitOfWork");

            UnitOfWork = unitOfWork;
        }

        public TEntity ObterPorId(int id)
        {
            return GetSet().SingleOrDefault(o => o.Id == id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return GetSet().Select(o => o).AsEnumerable();
        }

        
        public void Salvar(TEntity entity)
        {
            if (entity.Id == default)
                GetSet().Add(entity);
            else
                UnitOfWork.SetModified(entity);

            UnitOfWork.Commit();
        }

        public void Excluir(TEntity entity)
        {
            GetSet().Remove(entity);

            UnitOfWork.Commit();
        }

        public bool ExisteAlgum(Expression<Func<TEntity, bool>> expression)
        {
            return GetSet().Any(expression);
        }

        private IDbSet<TEntity> GetSet()
        {
            return UnitOfWork.CreateSet<TEntity>();
        }
    }
}