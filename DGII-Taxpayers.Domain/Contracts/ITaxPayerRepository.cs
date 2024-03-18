using DGII_Taxpayers.Domain.DTOs;
using DGII_Taxpayers.Domain.Entitites;

namespace DGII_Taxpayers.Domain.Contracts;

public interface ITaxPayerRepository
{
    void CreateTaxPayerAsync(string rncId,
                             string name,
                             PersonType personType,
                             string status);

    Task<bool> IsTaxPayerRncIdNotAvaliable(string rncID);

    Task<List<TaxPayerDTO>> GetAllTaxPayer();

    Task<TaxPayer?> GetTaxPayerByRncId(string rncId);
}
