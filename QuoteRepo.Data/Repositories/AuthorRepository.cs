namespace QuoteRepo.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(QuoteContext context) : base(context)
        {
        }

        public async Task<Author> GetAuthorWithQuotes(int authorId)
        {
            return await _context.Authors.Include(a => a.Quotes).SingleOrDefaultAsync(a => a.Id == authorId);
        }
    }
}
