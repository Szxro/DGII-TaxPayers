using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.Core.Primitives;
using DGII_Taxpayers.Domain.DTOs;
using DGII_Taxpayers.Domain.Errors;

namespace DGII_Taxpayers.Application.TaxReceipts.Query.GetAllTaxReceiptByRncIdQuery;

public record GetAllTaxReceiptByRncIdQuery(string rncId) : ICachedQuery<Result<List<TaxReceiptDTO>>>
{
    public string CahedKey => $"tax-receipt-{rncId}";

    public TimeSpan Expiration => TimeSpan.FromMinutes(5);
}

public class GetAllTaxReceiptByRncIdQueryHandler : IQueryHandler<GetAllTaxReceiptByRncIdQuery, Result<List<TaxReceiptDTO>>>
{
    private readonly ITaxReceiptRepository _taxReceiptRepository;

    public GetAllTaxReceiptByRncIdQueryHandler(ITaxReceiptRepository taxReceiptRepository)
    {
        _taxReceiptRepository = taxReceiptRepository;
    }

    public async Task<Result<List<TaxReceiptDTO>>> Handle(GetAllTaxReceiptByRncIdQuery request, CancellationToken cancellationToken)
    {
        List<TaxReceiptDTO> foundTaxReceipts = await _taxReceiptRepository.GetTaxReceiptsByRncId(request.rncId);

        if (!foundTaxReceipts.Any())
        {
            return Result<List<TaxReceiptDTO>>.Failure(TaxReceiptErrors.NotTaxReceiptsFound);
        }

        return Result<List<TaxReceiptDTO>>.Success(foundTaxReceipts);
    }
}
