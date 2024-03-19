using FluentValidation;

namespace DGII_Taxpayers.Application.PersonTypes.Commands.CreatePersonTypeCommand;

public class CreatePersonTypeCommandValidator : AbstractValidator<CreatePersonTypeCommand>
{
    public CreatePersonTypeCommandValidator()
    {
        RuleFor(rule => rule.typeName).NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacio");

        RuleFor(rule => rule.typeName).NotNull().WithMessage("El campo {PropertyName} no puede estar nulo");
    }
}
