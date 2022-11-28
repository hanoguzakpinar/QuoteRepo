using QuoteRepo.Core.UnitOfWorks;

namespace QuoteRepo.Business.Services
{
    public class QuoteService : Service<Quote>, IQuoteService
    {
        public QuoteService(IRepository<Quote> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
