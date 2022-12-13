namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    public class GetAuthorWithQuotesQueryHandler : IRequestHandler<GetAuthorWithQuotesQueryRequest, Result<AuthorWithQuotesDto>>
    {
        private readonly IAuthorService _authorService;

        public GetAuthorWithQuotesQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<Result<AuthorWithQuotesDto>> Handle(GetAuthorWithQuotesQueryRequest request, CancellationToken cancellationToken)
        {
            return await _authorService.GetAuthorWithQuotes(request.Id);
        }
    }
}
