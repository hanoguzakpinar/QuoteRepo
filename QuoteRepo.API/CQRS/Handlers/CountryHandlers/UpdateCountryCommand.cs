namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class UpdateCountryCommand : IRequestHandler<UpdateCountryCommandRequest, Result<NoContentDto>>
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public UpdateCountryCommand(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<Result<NoContentDto>> Handle(UpdateCountryCommandRequest request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<Country>(request);
            await _countryService.UpdateAsync(mapped);
            return Result<NoContentDto>.Success(204);
        }
    }
}
