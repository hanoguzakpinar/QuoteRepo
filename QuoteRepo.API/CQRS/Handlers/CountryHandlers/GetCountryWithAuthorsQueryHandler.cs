namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class GetCountryWithAuthorsQueryHandler : IRequestHandler<GetCountryWithAuthorsQueryRequest, Result<CountryWithAuthorsDto>>
    {
        private readonly ICountryService _countryService;

        private readonly IMapper _mapper;
        public GetCountryWithAuthorsQueryHandler(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<Result<CountryWithAuthorsDto>> Handle(GetCountryWithAuthorsQueryRequest request, CancellationToken cancellationToken)
        {
            return await _countryService.GetCountryWithAuthors(request.Id);
        }
    }
}
