using Dominio.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dominio.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        TEntity ObterPorId(int id);

        TEntity ObterObjeto(Expression<Func<TEntity, bool>> expression);

        bool ExisteAlgum(Expression<Func<TEntity, bool>> expression);

        IEnumerable<TEntity> ObterTodos();

        IEnumerable<TEntity> ObterLista(Expression<Func<TEntity, bool>> expression);

        void Salvar(TEntity entity);

        void Excluir(TEntity entity);
    }
}