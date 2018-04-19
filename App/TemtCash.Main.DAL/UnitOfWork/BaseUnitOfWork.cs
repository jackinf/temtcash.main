using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace SpeysCloud.Main.DAL.UnitOfWork
{
    public abstract class BaseUnitOfWork : IDisposable
    {
        private IDbContextTransaction _transaction;
        private bool _isDisposed;

        public DbContext Context { get; }

        protected BaseUnitOfWork(DbContext context)
        {
            Context = context;
        }

        public async Task<IDbContextTransaction> BeginTransaction() => _transaction = await Context.Database.BeginTransactionAsync();
        public void CommitTransaction() => _transaction.Commit();
        public void RollbackTransaction() => _transaction.Rollback();
        public async Task SaveChangesAsync() => await Context.SaveChangesAsync();

        /// <summary>
        /// It's just a helper which encapsulates the start of transaction
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public async Task<T> TryExecuteTransactionThenSaveAndCommitOrRollback<T>(Func<IDbContextTransaction, Task<T>> action)
        {
            using (var transaction = await BeginTransaction())
            {
                try
                {
                    var result = await action(transaction);
                    await SaveChangesAsync();
                    CommitTransaction();
                    return result;
                }
                catch (Exception e)
                {
                    RollbackTransaction();
                    Console.WriteLine(e);
                    throw e;
                }
            }
        }

        private void Dispose(bool isDisposing)
        {
            if (!_isDisposed && isDisposing)
                Context.Dispose();
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}