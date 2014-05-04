using System;

namespace Domain.BaseObjects
{
    [Serializable]
    public abstract class Entity
    {
        public virtual int Id { get; protected set; }

        public virtual bool ExistsInDatabase()
        {
            return Id != 0;
        }

        public virtual DateTime Created { get; private set; }
        public virtual DateTime Modified { get; private set; }
    }
}
