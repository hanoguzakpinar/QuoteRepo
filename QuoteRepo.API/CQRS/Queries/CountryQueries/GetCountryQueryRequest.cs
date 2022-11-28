namespace QuoteRepo.API.CQRS.Queries.CountryQueries
{
    public class GetCountryQueryRequest : IRequest<Result<CountryDto>>
    {
        public int Id { get; set; }
        public GetCountryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
