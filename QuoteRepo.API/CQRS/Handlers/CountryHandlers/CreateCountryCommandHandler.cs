namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommandRequest, Result<CreateCountryCommandRequest>>
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CreateCountryCommandHandler(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<Result<CreateCountryCommandRequest>> Handle(CreateCountryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _countryService.AddAsync(_mapper.Map<Country>(request));
            return Result<CreateCountryCommandRequest>.Success(201, request);
        }
    }
}
