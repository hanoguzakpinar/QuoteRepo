namespace QuoteRepo.API.CQRS.Handlers.CountryHandlers
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommandRequest, Result<NoContentDto>>
    {
        private readonly ICountryService _countryService;

        public DeleteCountryCommandHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<Result<NoContentDto>> Handle(DeleteCountryCommandRequest request, CancellationToken cancellationToken)
        {
            var category = await _countryService.GetByIdAsync(request.Id);
            await _countryService.DeleteAsync(category);
            return Result<NoContentDto>.Success(204);
        }
    }
}
