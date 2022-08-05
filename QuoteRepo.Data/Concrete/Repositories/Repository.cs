using Microsoft.EntityFrameworkCore;
using QuoteRepo.Data.Abstract.Repositories;
using QuoteRepo.Data.Concrete.Contexts;
using System.Linq.Expressions;

namespace QuoteRepo.Data.Concrete.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly QuoteContext _context;

        public Repository(QuoteContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate)
        {
            return await (predicate == null ? _context.Set<T>().CountAsync() : _context.Set<T>().CountAsync(predicate));
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => { _context.Set<T>().Remove(entity); });
            await _context.SaveChangesAsync();
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, params Expression<Func<T, object>>[] includeProps)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate is not null)
                query = query.Where(predicate);

            if (includeProps.Any())
            {
                foreach (var prop in includeProps)
                {
                    query = query.Include(prop);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProps)
        {
            IQueryable<T> query = _context.Set<T>();
            query = query.Where(predicate);

            if (includeProps.Any())
            {
                foreach (var prop in includeProps)
                {
                    query = query.Include(prop);
                }
            }
            return await query.SingleOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => { _context.Set<T>().Update(entity); });
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
