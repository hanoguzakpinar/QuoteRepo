namespace QuoteRepo.Core.Services
{
    public interface ICountryService : IService<Country>
    {
        Task<Result<CountryWithAuthorsDto>> GetCountryWithAuthors(int categoryId);
    }
}
