using QuoteRepo.Core.Services;

namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    /*public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQueryRequest, Result<IList<AuthorDto>>>
    {
        private readonly IAuthorService _authorService;

        public GetAllAuthorsQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<Result<IList<AuthorDto>>> Handle(GetAllAuthorsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _authorService.GetAllAsync();
        }
    }*/
}
