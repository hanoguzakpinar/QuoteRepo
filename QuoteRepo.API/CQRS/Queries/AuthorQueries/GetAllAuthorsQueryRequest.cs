namespace QuoteRepo.API.CQRS.Queries.AuthorQueries
{
    public class GetAllAuthorsQueryRequest : IRequest<IDataResult<IList<AuthorDto>>>
    {
    }
}
