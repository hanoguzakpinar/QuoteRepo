namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommandRequest, IResult>
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CreateCountryCommandHandler(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(CreateCountryCommandRequest request, CancellationToken cancellationToken)
        {
            CreateCountryCommandValidator validator = new();
            var valResult = await validator.ValidateAsync(request, cancellationToken);
            if (valResult.Errors.Count > 0)
                return new Result(ResultStatus.Error, errors: valResult.Errors);

            return await _countryService.CreateAsync(_mapper.Map<CountryDto>(request));
        }
    }
}
