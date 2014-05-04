using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Domain.BaseObjects;
using NHibernate;
using NHibernate.Linq;

namespace Data.Repositories
{
    public abstract class BaseRepository<T>: IRepository<T> where T: Entity
    {
        public abstract ISession Session { get; }

        public virtual T Get(int id)
        {
            return Session.Get<T>(id);
        }

        public virtual T Get(Expression<Func<T, bool>> expression)
        {
            return Session.Query<T>().SingleOrDefault(expression);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public virtual IEnumerable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return Session.Query<T>().Where(expression);
        }

        public virtual void Save(T entity)
        {
            if (!entity.ExistsInDatabase())
            {
                typeof(T).GetProperty("Created").SetValue(entity, DateTime.UtcNow, null);
            }

            typeof (T).GetProperty("Modified").SetValue(entity, DateTime.UtcNow, null);

            Session.Save(entity);
        }
    }
}
