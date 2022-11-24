using QuoteRepo.Core.UnitOfWorks;

namespace QuoteRepo.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuoteContext _context;

        public UnitOfWork(QuoteContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
