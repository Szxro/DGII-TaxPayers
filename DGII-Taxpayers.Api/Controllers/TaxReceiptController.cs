using DGII_Taxpayers.Domain.Core.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DGII_Taxpayers.Application.TaxReceipts.Commands.CreateTaxReceiptCommand;
using DGII_Taxpayers.Api.Extensions;
using DGII_Taxpayers.Domain.DTOs;
using DGII_Taxpayers.Application.TaxReceipts.Query.GetAllTaxReceiptQuery;
using DGII_Taxpayers.Application.TaxReceipts.Query.GetAllTaxReceiptByRncIdQuery;
using System.Net;

namespace DGII_Taxpayers.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class TaxReceiptController : ControllerBase
    {
        private readonly ISender _sender;

        public TaxReceiptController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("taxreceipt/create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]

        public async Task<ActionResult> CreateTaxReceipt(CreateTaxReceiptCommand createTaxReceipt)
        {
            Result result = await _sender.Send(createTaxReceipt);

            return result.IsSuccess ? NoContent() : result.ToProblemDetails();
        }

        [HttpGet("taxreceipt/all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<List<TaxReceiptDTO>>> GetAllTaxReceipts()
        {
            Result<List<TaxReceiptDTO>> result = await _sender.Send(new GetAllTaxReceiptQuery());

            return result.IsSuccess ? Ok(result.Data) : result.ToProblemDetails();
        }

        [HttpGet("taxreceipt/byRncId")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<List<TaxReceiptDTO>>> GetAllTaxReceiptsByRncId(string rncId)
        {
            Result<List<TaxReceiptDTO>> result = await _sender.Send(new GetAllTaxReceiptByRncIdQuery(rncId));

            return result.IsSuccess ? Ok(result.Data) : result.ToProblemDetails();
        }

    }
}
