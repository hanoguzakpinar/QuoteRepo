namespace QuoteRepo.API.CQRS.Queries.QuoteQueries
{
    public class GetQuoteQueryRequest : IRequest<Result<QuoteDto>>
    {
        public int Id { get; set; }
        public GetQuoteQueryRequest(int id)
        {
            Id = id;
        }
    }
}
