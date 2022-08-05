using QuoteRepo.Entities.Dtos;

namespace QuoteRepo.Business.Abstract
{
    public interface ICountryService
    {
        Task<IList<CountryDto>> GetAllAsync();
        Task<CountryDto> GetAsync(int id);
    }
}
