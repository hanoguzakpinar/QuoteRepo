namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQueryRequest, Result<List<AuthorDto>>>
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public GetAllAuthorsQueryHandler(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public async Task<Result<List<AuthorDto>>> Handle(GetAllAuthorsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _authorService.GetAllAsync();
            var mapped = _mapper.Map<List<AuthorDto>>(products);
            return Result<List<AuthorDto>>.Success(200, mapped);
        }
    }
}
