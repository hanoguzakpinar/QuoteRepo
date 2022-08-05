using QuoteRepo.Entities.Dtos;
using QuoteRepo.Shared.Results;

namespace QuoteRepo.Business.Abstract
{
    public interface ICountryService
    {
        Task<IDataResult<IList<CountryDto>>> GetAllAsync();
        Task<IDataResult<CountryDto>> GetAsync(int id);
    }
}
