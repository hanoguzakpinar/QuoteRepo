namespace QuoteRepo.Business.Abstract
{
    public interface ICountryService
    {
        Task<IDataResult<IList<CountryDto>>> GetAllAsync();
        Task<IDataResult<CountryDto>> GetAsync(int id);
        Task<IResult> CreateAsync(CountryDto entity);
        Task<IResult> UpdateAsync(CountryDto entity);
        Task<IResult> DeleteAsync(int id);
        Task<bool> AnyAsync(int id);
    }
}
