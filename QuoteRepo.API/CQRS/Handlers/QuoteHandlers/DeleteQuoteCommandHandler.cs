namespace QuoteRepo.API.CQRS.Handlers.QuoteHandlers
{
    public class DeleteQuoteCommandHandler : IRequestHandler<DeleteQuoteCommandRequest, Result<NoContentDto>>
    {
        private readonly IQuoteService _quoteService;
        private readonly IMapper _mapper;

        public DeleteQuoteCommandHandler(IQuoteService quoteService, IMapper mapper)
        {
            _quoteService = quoteService;
            _mapper = mapper;
        }

        public async Task<Result<NoContentDto>> Handle(DeleteQuoteCommandRequest request, CancellationToken cancellationToken)
        {
            var quote = await _quoteService.GetByIdAsync(request.Id);
            await _quoteService.DeleteAsync(quote);
            return Result<NoContentDto>.Success(204);
        }
    }
}
