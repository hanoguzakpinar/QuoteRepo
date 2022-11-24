using QuoteRepo.Core.Services;

namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommandRequest, IResult>
    {
        private readonly ICountryService _countryService;

        public DeleteCountryCommandHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<IResult> Handle(DeleteCountryCommandRequest request, CancellationToken cancellationToken)
        {
            DeleteCountryCommandValidator validator = new();
            var valResult = await validator.ValidateAsync(request, cancellationToken);
            if (valResult.Errors.Count > 0)
                return new Result(ResultStatus.Error, errors: valResult.Errors);

            return await _countryService.DeleteAsync(request.Id);
        }
    }
}
