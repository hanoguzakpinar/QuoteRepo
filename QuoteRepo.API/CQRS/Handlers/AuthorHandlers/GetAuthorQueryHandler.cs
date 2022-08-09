namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQueryRequest, IDataResult<AuthorDto>>
    {
        private readonly IAuthorService _authorService;

        public GetAuthorQueryHandler(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IDataResult<AuthorDto>> Handle(GetAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            GetAuthorQueryValidator validator = new();
            var valResult = await validator.ValidateAsync(request);
            if (valResult.Errors.Count > 0)
                return new DataResult<AuthorDto>(ResultStatus.Error, errors: valResult.Errors);

            return await _authorService.GetAsync(request.Id);
        }
    }
}
