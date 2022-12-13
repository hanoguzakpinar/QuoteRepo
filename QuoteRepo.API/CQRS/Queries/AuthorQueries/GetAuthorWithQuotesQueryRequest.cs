namespace QuoteRepo.API.CQRS.Queries.AuthorQueries
{
    public class GetAuthorWithQuotesQueryRequest : IRequest<Result<AuthorWithQuotesDto>>
    {
        public int Id { get; set; }

        public GetAuthorWithQuotesQueryRequest(int id)
        {
            Id = id;
        }
    }
}
