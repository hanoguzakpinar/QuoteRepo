namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class GetCountryQueryHandler : IRequestHandler<GetCountryQueryRequest, Result<CountryDto>>
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public GetCountryQueryHandler(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<Result<CountryDto>> Handle(GetCountryQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await _countryService.GetByIdAsync(request.Id);
            var mapped = _mapper.Map<CountryDto>(category);
            return Result<CountryDto>.Success(200, mapped);
        }
    }
}
