using System;
using NHibernate;

namespace Utilities.Transactions
{
    public class Transaction: IDisposable
    {
        private readonly ISession _session;
        private readonly bool _isAlreadyInTransaction;

        public Transaction(ISession session)
        {
            _session = session;

            _isAlreadyInTransaction = session.Transaction.IsActive;

            if (!_isAlreadyInTransaction)
            {
                session.BeginTransaction();
            }
        }

        public void Commit()
        {
            if (!_isAlreadyInTransaction)
            {
                _session.Transaction.Commit();
            }
        }

        public void Rollback()
        {
            _session.Transaction.Rollback();
        }

        public void Dispose()
        {
            if (!_isAlreadyInTransaction && _session.Transaction.IsActive)
            {
                _session.Transaction.Rollback();
            }
        }
    }
}
