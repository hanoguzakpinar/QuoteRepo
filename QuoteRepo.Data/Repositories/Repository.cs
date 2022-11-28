namespace QuoteRepo.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly QuoteContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(QuoteContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            return await (predicate == null ? _dbSet.CountAsync() : _dbSet.CountAsync(predicate));
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => { _dbSet.Remove(entity); });
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => { _dbSet.Update(entity); });
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }
    }
}
