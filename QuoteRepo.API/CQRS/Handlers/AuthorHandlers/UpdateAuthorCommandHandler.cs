namespace QuoteRepo.API.CQRS.Handlers.AuthorHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommandRequest, IResult>
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(UpdateAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            UpdateAuthorCommandValidator validator = new();
            var valResult = await validator.ValidateAsync(request);
            if (valResult.Errors.Count > 0)
                return new Result(ResultStatus.Error, errors: valResult.Errors);

            return await _authorService.UpdateAsync(_mapper.Map<UpdateAuthorDto>(request));
        }
    }
}
