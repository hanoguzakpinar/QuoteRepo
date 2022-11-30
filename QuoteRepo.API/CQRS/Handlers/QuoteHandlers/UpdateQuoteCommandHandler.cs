namespace QuoteRepo.API.CQRS.Handlers.QuoteHandlers
{
    public class UpdateQuoteCommandHandler : IRequestHandler<UpdateQuoteCommandRequest, Result<NoContentDto>>
    {
        private readonly IQuoteService _quoteService;
        private readonly IMapper _mapper;

        public UpdateQuoteCommandHandler(IQuoteService quoteService, IMapper mapper)
        {
            _quoteService = quoteService;
            _mapper = mapper;
        }

        public async Task<Result<NoContentDto>> Handle(UpdateQuoteCommandRequest request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<Quote>(request);
            await _quoteService.UpdateAsync(mapped);
            return Result<NoContentDto>.Success(204);
        }
    }
}
