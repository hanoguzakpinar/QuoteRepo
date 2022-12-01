using QuoteRepo.API.Filters;

namespace QuoteRepo.API.Controllers
{
    public class QuotesController : MainController
    {
        private readonly IMediator _mediator;

        public QuotesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllQuotesQueryRequest());
            return CreateActionResult(result);
        }

        [ServiceFilter(typeof(NotFoundFilter<Quote>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetQuoteQueryRequest(id));
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuoteCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return CreateActionResult(result);
        }

        [ServiceFilter(typeof(NotFoundFilter<Quote>))]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateQuoteCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return CreateActionResult(result);
        }

        [ServiceFilter(typeof(NotFoundFilter<Quote>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteQuoteCommandRequest(id));
            return CreateActionResult(result);
        }
    }
}
