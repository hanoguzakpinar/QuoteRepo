global using IResult = QuoteRepo.Shared.Results.IResult;
using QuoteRepo.API.CQRS.Commands.CountryCommands;
using QuoteRepo.Business.Abstract;
using QuoteRepo.Entities.Dtos;
using QuoteRepo.Shared.Results;

namespace QuoteRepo.API.CQRS.CountryHandlers
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommandRequest, IResult>
    {
        private readonly ICountryService _countryService;

        public CreateCountryCommandHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<IResult> Handle(CreateCountryCommandRequest request, CancellationToken cancellationToken)
        {
            CreateCountryCommandValidator validator = new();
            var valResult = await validator.ValidateAsync(request, cancellationToken);
            if (valResult.Errors.Count > 0)
                return new Result(ResultStatus.Error, errors: valResult.Errors);

            return await _countryService.CreateAsync(new CountryDto { Name = request.Name });
        }
    }
}
