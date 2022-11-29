namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommandRequest, Result<CreateAuthorCommandRequest>>
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public async Task<Result<CreateAuthorCommandRequest>> Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorService.AddAsync(_mapper.Map<Author>(request));
            return Result<CreateAuthorCommandRequest>.Success(201, request);
        }
    }
}
