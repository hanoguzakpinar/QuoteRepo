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
        private readonly IMediator mediator;

        public CountriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new GetAllCountriesQueryRequest());
            if (result.ResultStatus == ResultStatus.Error)
            {
                return BadRequest(result.Message);
            }
            return Ok(result.Data);
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
            await mediator.Send(request);
            return Created("", request);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            GetCountryQueryRequest request = new(id);
            var result = await mediator.Send(request);

            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result.Data);
            }
            return result.Errors is not null ? BadRequest(new { Errors = result.Errors.Select(x => x.ErrorMessage), Message = result.Message }) : BadRequest(new { ResultStatus=result.ResultStatus.ToString(), Message = result.Message });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeleteCountryCommandRequest request = new(id);
            DeleteCountryCommandValidator validator = new();
            var result = validator.Validate(request);
            if (result.Errors.Count > 0)
            {
                return BadRequest(new { Count = result.Errors.Count, ErrorMessages = result.Errors.Select(x => x.ErrorMessage) });
            }//handler a taşınabilir.

            var _result = await mediator.Send(request);
            return Ok(_result);
        }
    }
}
