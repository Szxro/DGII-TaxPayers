using DGII_Taxpayers.Domain.DTOs;
using DGII_Taxpayers.Domain.Entitites;

namespace DGII_Taxpayers.Domain.Contracts;

public interface IPersonTypeRepository
{
    Task AddDefaultPersonType();

    void CreatePersonType(string typeName);

    Task<bool> IsPersonTypeNameFound(string typeName);

    Task<PersonType?> GetPersonTypeByTypeName(string typeName);

    Task<List<PersonTypeDTO>> GetAllPersonType();
}
