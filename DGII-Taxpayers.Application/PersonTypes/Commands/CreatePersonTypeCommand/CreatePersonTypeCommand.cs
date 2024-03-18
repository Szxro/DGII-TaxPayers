using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.Core.Primitives;
using DGII_Taxpayers.Domain.Errors;

namespace DGII_Taxpayers.Application.PersonTypes.Commands.CreatePersonTypeCommand;

public record CreatePersonTypeCommand(string typeName) : ICommand<Result> { }

public class CreatePersonTypeCommandHandler : ICommandHandler<CreatePersonTypeCommand, Result>
{
    private readonly IPersonTypeRepository _personTypeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreatePersonTypeCommandHandler(IPersonTypeRepository personTypeRepository,
                                          IUnitOfWork unitOfWork)
    {
        _personTypeRepository = personTypeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreatePersonTypeCommand request, CancellationToken cancellationToken)
    {
        if (await _personTypeRepository.IsPersonTypeNameFound(request.typeName))
        {
            return Result.Failure(PersonTypeErrors.NotUnique);
        }

         _personTypeRepository.CreatePersonType(request.typeName);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
