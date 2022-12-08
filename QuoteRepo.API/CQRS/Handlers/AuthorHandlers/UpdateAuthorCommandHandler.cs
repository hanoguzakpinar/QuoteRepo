namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, Result<NoContentDto>>
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

        public async Task<Result<NoContentDto>> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            var hasEntity = _countryService.AnyAsync(x => x.Id == request.CountryId);
            if (!hasEntity.Result)
                throw new NotFoundException(Message.NotFound<Country>(request.CountryId));

            await _authorService.UpdateAsync(_mapper.Map<Author>(request));
            return Result<NoContentDto>.Success(204);
        }
    }
}
