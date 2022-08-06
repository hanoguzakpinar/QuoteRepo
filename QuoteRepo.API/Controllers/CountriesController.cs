global using MediatR;
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
            var result = await _mediator.Send(new GetCountryQueryRequest(id));

            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result.Data);
            }

            return result.Errors is not null ? BadRequest(new { Errors = result.Errors.Select(x => x.ErrorMessage) }) : BadRequest(new { ResultStatus = result.ResultStatus.ToString(), Message = result.Message });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCountryCommandRequest(id));
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Ok(result);
            }
            return result.Errors is not null ? BadRequest(new { Errors = result.Errors.Select(x => x.ErrorMessage) }) : BadRequest(new { ResultStatus = result.ResultStatus.ToString(), Message = result.Message });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return Created("", result);
            }
            return result.Errors is not null ? BadRequest(new { Errors = result.Errors.Select(x => x.ErrorMessage) }) : BadRequest(new { ResultStatus = result.ResultStatus.ToString(), Message = result.Message });
        }
    }
}
