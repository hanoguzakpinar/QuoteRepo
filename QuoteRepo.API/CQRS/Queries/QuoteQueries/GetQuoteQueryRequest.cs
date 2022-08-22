namespace QuoteRepo.API.CQRS.Queries.QuoteQueries
{
    public class GetQuoteQueryRequest : IRequest<IDataResult<QuoteDto>>
    {
        public int Id { get; set; }
        public GetQuoteQueryRequest(int id)
        {
            Id = id;
        }
    }
}
