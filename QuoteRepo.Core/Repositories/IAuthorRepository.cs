namespace QuoteRepo.Core.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<Author> GetAuthorWithQuotes(int authorId);
    }
}
