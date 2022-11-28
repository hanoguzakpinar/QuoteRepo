namespace QuoteRepo.API.CQRS.Queries.QuoteQueries
{
    public class GetAllQuotesQueryRequest : IRequest<Result<IList<QuoteDto>>>
    {
    }
}
