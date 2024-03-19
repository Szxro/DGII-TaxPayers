using DGII_Taxpayers.Api.Extensions;
using DGII_Taxpayers.Application.PersonTypes.Commands.CreatePersonTypeCommand;
using DGII_Taxpayers.Application.PersonTypes.Queries.GetAllPersonTypeQuery;
using DGII_Taxpayers.Domain.Core.Primitives;
using DGII_Taxpayers.Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DGII_Taxpayers.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class PersonTypeController : ControllerBase
    {
        private readonly ISender _sender;

        public PersonTypeController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet("persontypes/all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<List<PersonTypeDTO>>> GetAllPersonType()
        {
            Result<List<PersonTypeDTO>> result = await _sender.Send(new GetAllPersonTypeQuery());

            return result.IsSuccess ? Ok(result.Data) : result.ToProblemDetails();
        }

        [HttpPost("persontype/create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]

        public async Task<ActionResult> CreatePersonType(CreatePersonTypeCommand createPersonType)
        {
            Result result = await _sender.Send(createPersonType);

            return result.IsSuccess ? NoContent() : result.ToProblemDetails();
        }
    }
}
