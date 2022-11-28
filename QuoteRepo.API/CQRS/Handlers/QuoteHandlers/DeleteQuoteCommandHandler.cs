using QuoteRepo.Core.Services;

namespace QuoteRepo.API.CQRS.Handlers.QuoteHandlers
{
    /*public class DeleteQuoteCommandHandler : IRequestHandler<DeleteQuoteCommandRequest, IResult>
    {
        private readonly IQuoteService _quoteService;
        private readonly IMapper _mapper;

        public DeleteQuoteCommandHandler(IQuoteService quoteService, IMapper mapper)
        {
            _quoteService = quoteService;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(DeleteQuoteCommandRequest request, CancellationToken cancellationToken)
        {
            DeleteQuoteCommandValidator validator = new();
            var valResult = await validator.ValidateAsync(request, cancellationToken);
            if (valResult.Errors.Count > 0)
                return new Result(ResultStatus.Error, errors: valResult.Errors);

            return await _quoteService.DeleteAsync(request.Id);
        }
    }*/
}
