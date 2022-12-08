namespace QuoteRepo.API.Controllers
{
    public class AuthorsController : MainController
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllAuthorsQueryRequest());
            return CreateActionResult(result);
        }

        [ServiceFilter(typeof(NotFoundFilter<Author>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetAuthorQueryRequest(id));
            return CreateActionResult(result);
        }

        [ServiceFilter(typeof(NotFoundFilter<Author>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteAuthorCommandRequest(id));
            return CreateActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return CreateActionResult(result);
        }

        [ServiceFilter(typeof(NotFoundFilter<Author>))]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAuthorCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return CreateActionResult(result);
        }
    }
}
