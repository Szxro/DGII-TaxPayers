using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.Core.Primitives;
using DGII_Taxpayers.Domain.Entitites;
using DGII_Taxpayers.Domain.Errors;

namespace DGII_Taxpayers.Application.TaxReceipts.Commands.CreateTaxReceiptCommand;

public record CreateTaxReceiptCommand(string rncId,
                                      string ncf,
                                      string amount) : ICommand<Result> { }

public class CreateTaxReceiptCommandHandler : ICommandHandler<CreateTaxReceiptCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITaxReceiptRepository _taxReceiptRepository;
    private readonly ITaxPayerRepository _taxPayerRepository;

    public CreateTaxReceiptCommandHandler(IUnitOfWork unitOfWork,
                                          ITaxReceiptRepository taxReceiptRepository,
                                          ITaxPayerRepository taxPayerRepository)
    {
        _unitOfWork = unitOfWork;
        _taxReceiptRepository = taxReceiptRepository;
        _taxPayerRepository = taxPayerRepository;
    }

    public async Task<Result> Handle(CreateTaxReceiptCommand request, CancellationToken cancellationToken)
    {
        TaxPayer? foundTaxPayer = await _taxPayerRepository.GetTaxPayerByRncId(request.rncId);

        if (foundTaxPayer is null)
        {
            return Result.Failure(TaxPayerErrors.NotFound);
        }

        if (await _taxReceiptRepository.IsNcfNotAvaliable(request.ncf))
        {
            return Result.Failure(TaxReceiptErrors.NotUnique);
        }

        _taxReceiptRepository.CreateTaxReceipt(foundTaxPayer, request.ncf, request.amount);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
