using CleaningManagement.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleaningManagement.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly CleaningManagementDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(CleaningManagementDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task<TEntity> Create(TEntity entity, CancellationToken ct)
        {
            await _dbSet.AddAsync(entity, ct);
            await _context.SaveChangesAsync(ct);
            return entity;
        }

        public async Task Delete(Guid id, CancellationToken ct)
        {
            var entity = await _dbSet.FindAsync(new object[] { id }, ct);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync(ct);
        }

        public async Task<IEnumerable<TEntity>> Get(CancellationToken ct)
        {
            return await _dbSet.AsNoTracking().ToListAsync(ct);
        }

        public async Task<TEntity> GetById(Guid id, CancellationToken ct)
        {
            return await _dbSet.FindAsync(new object[] { id }, ct);
        }

        public async Task<TEntity> Update(TEntity entity, CancellationToken ct)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(ct);
            return entity;
        }
    }
}
