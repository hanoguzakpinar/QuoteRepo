namespace QuoteRepo.API.Controllers
{
    public class CountriesController : MainController
    {
        private readonly IMediator _mediator;

        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCountriesQueryRequest());
            return CreateActionResult(result);
        }

        [ServiceFilter(typeof(NotFoundFilter<Country>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCountryQueryRequest(id));
            return CreateActionResult(result);
        }

        [ServiceFilter(typeof(NotFoundFilter<Country>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCountryCommandRequest(id));
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return CreateActionResult(result);
        }

        [ServiceFilter(typeof(NotFoundFilter<Country>))]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCountryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return CreateActionResult(result);
        }
    }
}
