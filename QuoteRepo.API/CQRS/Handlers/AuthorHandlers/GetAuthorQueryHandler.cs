namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQueryRequest, Result<AuthorDto>>
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public GetAuthorQueryHandler(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public async Task<Result<AuthorDto>> Handle(GetAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorService.GetByIdAsync(request.Id);
            var mapped = _mapper.Map<AuthorDto>(author);
            return Result<AuthorDto>.Success(200, mapped);
        }
    }
}
