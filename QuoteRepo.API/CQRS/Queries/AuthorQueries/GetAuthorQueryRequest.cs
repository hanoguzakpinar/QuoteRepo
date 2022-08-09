namespace QuoteRepo.API.CQRS.Queries.AuthorQueries
{
    public class GetAuthorQueryRequest : IRequest<IDataResult<AuthorDto>>
    {
        public int Id { get; set; }

        public GetAuthorQueryRequest(int id)
        {
            Id = id;
        }
    }
}
