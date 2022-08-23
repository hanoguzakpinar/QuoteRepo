namespace QuoteRepo.API.CQRS.Handlers.QuoteHandlers
{
    public class UpdateQuoteCommandHandler : IRequestHandler<UpdateQuoteCommandRequest, IResult>
    {
        private readonly IQuoteService _quoteService;
        private readonly IMapper _mapper;

        public UpdateQuoteCommandHandler(IQuoteService quoteService, IMapper mapper)
        {
            _quoteService = quoteService;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(UpdateQuoteCommandRequest request, CancellationToken cancellationToken)
        {
            UpdateQuoteCommandValidator validator = new();
            var valResult = await validator.ValidateAsync(request, cancellationToken);
            if (valResult.Errors.Count > 0)
                return new Result(ResultStatus.Error, errors: valResult.Errors);

            return await _quoteService.UpdateAsync(_mapper.Map<UpdateQuoteDto>(request));
        }
    }
}
