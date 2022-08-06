namespace QuoteRepo.API.CQRS.Queries.CountryQueries
{
    public class GetCountryQueryRequest : IRequest<IDataResult<CountryDto>>
    {
        public int Id { get; set; }
        public GetCountryQueryRequest(int id)
        {
            Id = id;
        }
    }
}
