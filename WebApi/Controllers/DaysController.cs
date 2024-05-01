using Application.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("/dates/")]
public class DaysController : ControllerBase
{
	private readonly IMediator _mediator;

	public DaysController(IMediator mediator) =>
		_mediator = mediator;

	[HttpGet("")]
	public async Task<IActionResult> GetDates([FromQuery]DateRangeQuery dateRangeQuery, CancellationToken token) =>
		Ok(await _mediator.Send(dateRangeQuery, token));
}
