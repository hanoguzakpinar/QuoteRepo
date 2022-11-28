using QuoteRepo.Core.Services;

namespace QuoteRepo.API.CQRS.Handlers.QuoteHandlers
{
    /*public class CreateQuoteCommandHandler : IRequestHandler<CreateQuoteCommandRequest, IResult>
    {
        private readonly IQuoteService _quoteService;
        private readonly IMapper _mapper;

        public CreateQuoteCommandHandler(IQuoteService quoteService, IMapper mapper)
        {
            _quoteService = quoteService;
            _mapper = mapper;
        }

        public async Task<IResult> Handle(CreateQuoteCommandRequest request, CancellationToken cancellationToken)
        {
            CreateQuoteCommandValidator validator = new();
            var valResult = await validator.ValidateAsync(request, cancellationToken);
            if (valResult.Errors.Count > 0)
                return new Result(ResultStatus.Error, errors: valResult.Errors);

            return await _quoteService.CreateAsync(_mapper.Map<CreateQuoteDto>(request));
        }
    }*/
}
