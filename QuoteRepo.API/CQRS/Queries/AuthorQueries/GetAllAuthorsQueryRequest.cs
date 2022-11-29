namespace QuoteRepo.API.CQRS.Queries.AuthorQueries
{
    public class GetAllAuthorsQueryRequest : IRequest<Result<List<AuthorDto>>>
    {
    }
}
