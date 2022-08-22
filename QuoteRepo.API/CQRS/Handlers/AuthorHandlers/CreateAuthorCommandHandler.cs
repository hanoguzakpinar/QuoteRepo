namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommandRequest, IResult>
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            CreateAuthorCommandValidator validator = new();
            var valResult = await validator.ValidateAsync(request, cancellationToken);
            if (valResult.Errors.Count > 0)
                return new Result(ResultStatus.Error, errors: valResult.Errors);

            return await _authorService.CreateAsync(_mapper.Map<CreateAuthorDto>(request));
        }
    }
}
