using SM.DomainLayer.Interfaces;
using SM.InfractureLayer.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SM.InfractureLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public Hashtable _hasTable;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> CompleteAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// No matter an exception has been raised or not, this method always will dispose the DbContext 
        /// </summary>
        /// <returns></returns>
        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }

        public IGenericRepository<TEntity> Repository<TEntity>()
        {
            if (_hasTable == null) _hasTable = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_hasTable.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _hasTable.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_hasTable[type];
        }
    }
}
