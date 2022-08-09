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

            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result.Data);
            }

            return result.Errors is not null ? BadRequest(new { Errors = result.Errors.Select(x => x.ErrorMessage) }) : BadRequest(new { ResultStatus = result.ResultStatus.ToString(), Message = result.Message });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetAuthorQueryRequest(id));

            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result.Data);
            }

            return result.Errors is not null ? BadRequest(new { Errors = result.Errors.Select(x => x.ErrorMessage) }) : BadRequest(new { ResultStatus = result.ResultStatus.ToString(), Message = result.Message });
        }
    }
}
