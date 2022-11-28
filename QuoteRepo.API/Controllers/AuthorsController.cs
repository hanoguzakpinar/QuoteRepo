namespace QuoteRepo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
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

            /*if (result.StatusCode == 2)
            {
                return Ok(result.Data);
            }*/

            return BadRequest(/*Utility.ReturnErrors(result)*/);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetAuthorQueryRequest(id));

            /*if (result.StatusCode == ResultStatus.Success)
            {
                return Ok(result.Data);
            }*/

            return BadRequest(/*Utility.ReturnErrors(result)*/);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteAuthorCommandRequest(id));

            /*if (result.StatusCode == ResultStatus.Success)
            {
                return Ok(result);
            }*/

            return BadRequest(/*Utility.ReturnErrors(result)*/);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorCommandRequest request)
        {
            var result = await _mediator.Send(request);

           /* if (result.StatusCode == ResultStatus.Success)
            {
                return Ok(result);
            }*/

            return BadRequest(/*Utility.ReturnErrors(result)*/);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAuthorCommandRequest request)
        {
            var result = await _mediator.Send(request);

            /*if (result.StatusCode == ResultStatus.Success)
            {
                return Ok(result);
            }*/

            return BadRequest(/*Utility.ReturnErrors(result)*/);
        }
    }
}
