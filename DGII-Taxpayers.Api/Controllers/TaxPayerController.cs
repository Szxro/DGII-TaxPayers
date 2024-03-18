using DGII_Taxpayers.Api.Extensions;
using DGII_Taxpayers.Application.TaxPayers.Commands.CreateTaxPayerCommand;
using DGII_Taxpayers.Application.TaxPayers.Query.GetAllTaxPayersQuery;
using DGII_Taxpayers.Domain.Core.Primitives;
using DGII_Taxpayers.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DGII_Taxpayers.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class TaxPayerController : ControllerBase
    {
        private readonly ISender _sender;

        public TaxPayerController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("taxpayer/create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        public async Task<ActionResult> CreateTaxPayer(CreateTaxPayerCommand createTaxPayer)
        {
            Result result = await _sender.Send(createTaxPayer);

            return result.IsSuccess ? NoContent() : result.ToProblemDetails();
        }

        [HttpGet("taxpayer/all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<List<TaxPayerDTO>>> GetAllTaxPayers()
        {
            Result<List<TaxPayerDTO>> result = await _sender.Send(new GetAllTaxPayersQuery());

            return result.IsSuccess ? Ok(result.Data) : result.ToProblemDetails();
        }
    }
}
