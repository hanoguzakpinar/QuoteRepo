namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, IResult>
    {
        private readonly IAuthorService _authorService;
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorService authorService, IMapper mapper, ICountryService countryService)
        {
            _authorService = authorService;
            _mapper = mapper;
            _countryService = countryService;
        }

        public async Task<IResult> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            UpdateAuthorCommandValidator validator = new();
            var valResult = await validator.ValidateAsync(request);
            if (valResult.Errors.Count > 0)
                return new Result(ResultStatus.Error, errors: valResult.Errors);

            if (!await _countryService.AnyAsync(request.CountryId))
                return new Result(ResultStatus.Error, "CountryId veritabanında kayıtlı değil.");

            return await _authorService.UpdateAsync(_mapper.Map<UpdateAuthorDto>(request));
        }
    }
}
