namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommandRequest, Result<CreateAuthorCommandRequest>>
    {
        private readonly IAuthorService _authorService;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorService authorService, IMapper mapper, ICountryService countryService)
        {
            _authorService = authorService;
            _mapper = mapper;
            _countryService = countryService;
        }

        public async Task<Result<CreateAuthorCommandRequest>> Handle(CreateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var hasEntity = _countryService.AnyAsync(x => x.Id == request.CountryId);
            if (!hasEntity.Result)
                throw new NotFoundException(Message.NotFound<Country>(request.CountryId));

            var author = await _authorService.AddAsync(_mapper.Map<Author>(request));
            return Result<CreateAuthorCommandRequest>.Success(201, request);
        }
    }
}
