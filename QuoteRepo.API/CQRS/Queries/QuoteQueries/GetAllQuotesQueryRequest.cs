namespace QuoteRepo.API.CQRS.Queries.QuoteQueries
{
    public class GetAllQuotesQueryRequest : IRequest<Result<List<QuoteDto>>>
    {
    }
}
