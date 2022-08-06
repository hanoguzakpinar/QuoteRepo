namespace QuoteRepo.API.CQRS.Results.CountryResults
{
    public class GetAllCountriesQueryResult
    {
        List<CountryDto>? Countries { get; set; }
    }
}
