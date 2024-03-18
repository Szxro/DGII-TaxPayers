using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.Core.Primitives;
using DGII_Taxpayers.Domain.DTOs;
using DGII_Taxpayers.Domain.Errors;

namespace DGII_Taxpayers.Application.TaxReceipts.Query.GetAllTaxReceiptQuery
{
    public record GetAllTaxReceiptQuery : ICachedQuery<Result<List<TaxReceiptDTO>>>
    {
        public string CahedKey => "tax-receipts";

        public TimeSpan Expiration => TimeSpan.FromMinutes(5);
    }

    public class GetAllTaxReceiptQueryHandler : IQueryHandler<GetAllTaxReceiptQuery, Result<List<TaxReceiptDTO>>>
    {
        private readonly ITaxReceiptRepository _taxReceiptRepository;

        public GetAllTaxReceiptQueryHandler(ITaxReceiptRepository taxReceiptRepository)
        {
            _taxReceiptRepository = taxReceiptRepository;
        }

        public async Task<Result<List<TaxReceiptDTO>>> Handle(GetAllTaxReceiptQuery request, CancellationToken cancellationToken)
        {
            List<TaxReceiptDTO> allTaxReceipts = await _taxReceiptRepository.GetAllTaxReceipt();

            if (allTaxReceipts is null)
            {
                return Result<List<TaxReceiptDTO>>.Failure(TaxReceiptErrors.NoneTaxReceipts);
            }

            return Result<List<TaxReceiptDTO>>.Success(allTaxReceipts);
        }
    }
}
