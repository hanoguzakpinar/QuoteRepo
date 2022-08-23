namespace QuoteRepo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
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

            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(Utility.ReturnErrors(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetQuoteQueryRequest(id));

            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(Utility.ReturnErrors(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuoteCommandRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }

            return BadRequest(Utility.ReturnErrors(result));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateQuoteCommandRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }

            return BadRequest(Utility.ReturnErrors(result));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteQuoteCommandRequest request)
        {
            var result = await _mediator.Send(request);

            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }

            return BadRequest(Utility.ReturnErrors(result));
        }
    }
}
