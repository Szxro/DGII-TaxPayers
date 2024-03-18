using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.Core.Primitives;
using DGII_Taxpayers.Domain.DTOs;
using DGII_Taxpayers.Domain.Errors;

namespace DGII_Taxpayers.Application.TaxPayers.Query.GetAllTaxPayersQuery;

public class GetAllTaxPayersQuery : ICachedQuery<Result<List<TaxPayerDTO>>>
{
    public string CahedKey => "tax-payers";

    public TimeSpan Expiration => TimeSpan.FromMinutes(5);
}

public class GetAllTaxPayersQueryHandler : IQueryHandler<GetAllTaxPayersQuery, Result<List<TaxPayerDTO>>>
{
    private readonly ITaxPayerRepository _taxPayerRepository;

    public GetAllTaxPayersQueryHandler(ITaxPayerRepository taxPayerRepository)
    {
        _taxPayerRepository = taxPayerRepository;
    }

    public async Task<Result<List<TaxPayerDTO>>> Handle(GetAllTaxPayersQuery request, CancellationToken cancellationToken)
    {
        List<TaxPayerDTO> result = await _taxPayerRepository.GetAllTaxPayer();

        if (!result.Any())
        {
            return Result<List<TaxPayerDTO>>.Failure(TaxPayerErrors.NoneTaxPayers);
        }

        return Result<List<TaxPayerDTO>>.Success(result);
    }
}
