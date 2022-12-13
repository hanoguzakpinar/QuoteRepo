namespace QuoteRepo.Core.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        Task<Country> GetCountryWithAuthors(int countryId);
    }
}
