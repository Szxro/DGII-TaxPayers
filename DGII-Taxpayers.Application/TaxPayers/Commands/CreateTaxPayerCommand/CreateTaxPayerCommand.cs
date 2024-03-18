using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.Core.Primitives;
using DGII_Taxpayers.Domain.Entitites;
using DGII_Taxpayers.Domain.Errors;

namespace DGII_Taxpayers.Application.TaxPayers.Commands.CreateTaxPayerCommand;

public record CreateTaxPayerCommand(string rncId,
                                    string name,
                                    string personTypeName,
                                    string status) : ICommand<Result>
{ }

public class CreateTaxPayerCommandHandler : ICommandHandler<CreateTaxPayerCommand, Result>
{
    private readonly IPersonTypeRepository _personTypeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITaxPayerRepository _taxPayerRepository;

    public CreateTaxPayerCommandHandler(IPersonTypeRepository personTypeRepository,
                                        IUnitOfWork unitOfWork,
                                        ITaxPayerRepository taxPayerRepository)
    {
        _personTypeRepository = personTypeRepository;
        _unitOfWork = unitOfWork;
        _taxPayerRepository = taxPayerRepository;
    }
    public async Task<Result> Handle(CreateTaxPayerCommand request, CancellationToken cancellationToken)
    {
        PersonType? personType = await _personTypeRepository.GetPersonTypeByTypeName(request.personTypeName);

        if (personType is null)
        {
            return Result.Failure(PersonTypeErrors.NotFound);
        }

        if (await _taxPayerRepository.IsTaxPayerRncIdNotAvaliable(request.rncId))
        {
            return Result.Failure(TaxPayerErrors.NotUnique);
        }

        _taxPayerRepository.CreateTaxPayerAsync(request.rncId,request.name,personType,request.status);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
