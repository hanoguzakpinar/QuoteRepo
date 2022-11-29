namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    /*public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQueryRequest, Result<AuthorDto>>
    {
        private readonly IAuthorService _authorService;

        public GetAuthorQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<Result<AuthorDto>> Handle(GetAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            GetAuthorQueryValidator validator = new();
            var valResult = await validator.ValidateAsync(request);
            if (valResult.Errors.Count > 0)
                return Result<AuthorDto>.Fail(404, "XXX");

            return await _authorService.GetAsync(request.Id);
        }
    }*/
}
