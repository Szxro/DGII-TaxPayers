using FluentValidation;

namespace DGII_Taxpayers.Application.PersonTypes.Commands.CreatePersonTypeCommand;

public class CreatePersonTypeCommandValidator : AbstractValidator<CreatePersonTypeCommand>
{
    public CreatePersonTypeCommandValidator()
    {
        RuleFor(rule => rule.typeName).NotEmpty().WithMessage("The {PropertyName} cant be empty");

        RuleFor(rule => rule.typeName).NotNull().WithMessage("The {PropertyName} cant be null");

        RuleFor(rule => rule.typeName).Must(x => !string.IsNullOrEmpty(x)).WithMessage("The {PropertyName} cant be empty or null");
    }
}
