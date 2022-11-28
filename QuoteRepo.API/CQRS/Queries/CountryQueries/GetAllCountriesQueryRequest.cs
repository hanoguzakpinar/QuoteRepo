namespace QuoteRepo.API.CQRS.Queries.CountryQueries
{
    public class GetAllCountriesQueryRequest : IRequest<Result<IList<CountryDto>>>
    {
    }
}
