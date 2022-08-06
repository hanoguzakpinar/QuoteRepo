using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuoteRepo.API.CQRS.Commands.CountryCommands;
using QuoteRepo.API.CQRS.Queries.CountryQueries;
using QuoteRepo.Shared.Results;

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

            return result.Errors is not null ? BadRequest(new { Errors = result.Errors.Select(x => x.ErrorMessage) }) : BadRequest(new { ResultStatus = result.ResultStatus.ToString(), Message = result.Message });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetCountryQueryRequest request = new(id);
            var result = await _mediator.Send(request);

            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result.Data);
            }

            return result.Errors is not null ? BadRequest(new { Errors = result.Errors.Select(x => x.ErrorMessage) }) : BadRequest(new { ResultStatus = result.ResultStatus.ToString(), Message = result.Message });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteCountryCommandRequest request = new(id);

            var result = await _mediator.Send(request);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }
            return result.Errors is not null ? BadRequest(new { Errors = result.Errors.Select(x => x.ErrorMessage) }) : BadRequest(new { ResultStatus = result.ResultStatus.ToString(), Message = result.Message });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryCommandRequest request)
        {
            /*CreateCountryCommandValidator validator = new CreateCountryCommandValidator();
            validator.ValidateAndThrow(request);*/

            if (!ModelState.IsValid)//fluentValidation Dependency - Otomatik araya giriyor, hatayı fırlatıyor.
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(request);
            return Created("", request);
        }
    }
}
