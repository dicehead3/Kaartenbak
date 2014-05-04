using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NHibernate;

namespace Domain.BaseObjects
{
    public interface IRepository<T> where T: Entity
    {
        ISession Session { get; }
        T Get(int id);
        T Get(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);
        void Save(T entity);
    }
}
