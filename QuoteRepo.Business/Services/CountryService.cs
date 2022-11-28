using QuoteRepo.Core.UnitOfWorks;

namespace QuoteRepo.Business.Services
{
    public class CountryService : Service<Country>, ICountryService
    {
        public CountryService(IRepository<Country> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
