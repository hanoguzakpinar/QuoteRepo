namespace QuoteRepo.API.CQRS.Queries.QuoteQueries
{
    public class GetAllQuotesQueryRequest : IRequest<IDataResult<IList<QuoteDto>>>
    {
    }
}
