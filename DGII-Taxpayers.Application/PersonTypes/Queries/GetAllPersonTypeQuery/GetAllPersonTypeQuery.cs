using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.Core.Primitives;
using DGII_Taxpayers.Domain.DTOs;
using DGII_Taxpayers.Domain.Errors;

namespace DGII_Taxpayers.Application.PersonTypes.Queries.GetAllPersonTypeQuery;

public record GetAllPersonTypeQuery : ICachedQuery<Result<List<PersonTypeDTO>>>
{
    public string CahedKey => "person-types";

    public TimeSpan Expiration => TimeSpan.FromMinutes(5);
}

public class GetAllPersonTypeQueryHandler : IQueryHandler<GetAllPersonTypeQuery, Result<List<PersonTypeDTO>>>
{
    private readonly IPersonTypeRepository _personTypeRepository;

    public GetAllPersonTypeQueryHandler(IPersonTypeRepository personTypeRepository)
    {
        _personTypeRepository = personTypeRepository;
    }

    public async Task<Result<List<PersonTypeDTO>>> Handle(GetAllPersonTypeQuery request, CancellationToken cancellationToken)
    {
        List<PersonTypeDTO> foundPersonTypes = await _personTypeRepository.GetAllPersonType();

        if (!foundPersonTypes.Any())
        {
            return Result<List<PersonTypeDTO>>.Failure(PersonTypeErrors.NonePersonTypes);
        }

        return Result<List<PersonTypeDTO>>.Success(foundPersonTypes);
    }
}
