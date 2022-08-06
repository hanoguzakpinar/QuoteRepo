namespace QuoteRepo.API.CQRS.Queries.CountryQueries
{
    public class GetAllCountriesQueryRequest : IRequest<IDataResult<IList<CountryDto>>>
    {
    }
}
