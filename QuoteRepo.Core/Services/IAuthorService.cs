namespace QuoteRepo.Core.Services
{
    public interface IAuthorService : IService<Author>
    {
        Task<Result<AuthorWithQuotesDto>> GetAuthorWithQuotes(int authorId);
    }
}
