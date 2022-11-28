using QuoteRepo.Core.Services;

namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    /*public class UpdateCountryCommand : IRequestHandler<UpdateCountryCommandRequest, IResult>
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public UpdateCountryCommand(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(UpdateCountryCommandRequest request, CancellationToken cancellationToken)
        {
            UpdateCountryCommandValidator validator = new();
            var valResult = await validator.ValidateAsync(request, cancellationToken);
            if (valResult.Errors.Count > 0)
                return new Result(ResultStatus.Error, errors: valResult.Errors);

            return await _countryService.UpdateAsync(_mapper.Map<CountryDto>(request));
        }
    }*/
}
