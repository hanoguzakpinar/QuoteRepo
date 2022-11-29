namespace QuoteRepo.API.CQRS.Handlers.QuoteHandlers
{
    /*public class GetQuoteQueryHandler : IRequestHandler<GetQuoteQueryRequest, Result<QuoteDto>>
    {
        private readonly IQuoteService _quoteService;

        public GetQuoteQueryHandler(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        public async Task<Result<QuoteDto>> Handle(GetQuoteQueryRequest request, CancellationToken cancellationToken)
        {
            GetQuoteQueryValidator validator = new();
            var valResult = await validator.ValidateAsync(request, cancellationToken);
            if (valResult.Errors.Count > 0)
                return Result<QuoteDto>.Fail(404, "XXX");

            return await _quoteService.GetAsync(request.Id);
        }
    }*/
}
