using DGII_Taxpayers.Domain.DTOs;
using DGII_Taxpayers.Domain.Entitites;

namespace DGII_Taxpayers.Domain.Contracts;

public interface ITaxReceiptRepository
{
    void CreateTaxReceipt(TaxPayer taxPayer,
                          string ncf,
                          string amount);

    Task<bool> IsNcfNotAvaliable(string ncf);

    Task<List<TaxReceiptDTO>> GetAllTaxReceipt();

    Task<List<TaxReceiptDTO>> GetTaxReceiptsByRncId(string rncId);
}
