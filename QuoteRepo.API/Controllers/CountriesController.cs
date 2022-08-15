using QuoteRepo.Shared.Utils;

namespace QuoteRepo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
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

            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(ReturnErrors.ReturnObjectError(result));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCountryQueryRequest(id));

            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(ReturnErrors.ReturnObjectError(result));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCountryCommandRequest(id));
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }

            return BadRequest(ReturnErrors.ReturnObjectError(result));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Created("", result);
            }

            return BadRequest(ReturnErrors.ReturnObjectError(result));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCountryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }

            return BadRequest(ReturnErrors.ReturnObjectError(result));
        }
    }
}
