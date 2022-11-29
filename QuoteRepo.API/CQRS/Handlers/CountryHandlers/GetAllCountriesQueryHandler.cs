namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class GetAllCountriesQueryHandler : IRequestHandler<GetAllCountriesQueryRequest, Result<IList<CountryDto>>>
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public GetAllCountriesQueryHandler(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<Result<IList<CountryDto>>> Handle(GetAllCountriesQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _countryService.GetAllAsync();
            var mapped = _mapper.Map<IList<CountryDto>>(categories);
            return Result<IList<CountryDto>>.Success(200, mapped);
        }
    }
}
