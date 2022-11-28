using QuoteRepo.Core.UnitOfWorks;

namespace QuoteRepo.Business.Services
{
    public class AuthorService : Service<Author>, IAuthorService
    {
        public AuthorService(IRepository<Author> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
