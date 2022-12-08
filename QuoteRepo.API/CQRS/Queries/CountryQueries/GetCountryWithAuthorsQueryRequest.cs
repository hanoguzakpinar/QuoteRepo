namespace QuoteRepo.API.CQRS.Queries.CountryQueries
{
    public class GetCountryWithAuthorsQueryRequest : IRequest<Result<CountryWithAuthorsDto>>
    {
        public int Id { get; set; }
        public GetCountryWithAuthorsQueryRequest(int id)
        {
            Id = id;
        }
    }
}
