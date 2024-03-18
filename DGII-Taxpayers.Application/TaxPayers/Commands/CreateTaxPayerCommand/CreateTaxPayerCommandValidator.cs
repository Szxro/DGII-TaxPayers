using FluentValidation;

namespace DGII_Taxpayers.Application.TaxPayers.Commands.CreateTaxPayerCommand;

public class CreateTaxPayerCommandValidator : AbstractValidator<CreateTaxPayerCommand>
{
    public CreateTaxPayerCommandValidator()
    {
        RuleFor(x => x.rncId).NotEmpty().WithMessage("The {PropertyName} cant be empty");

        RuleFor(x => x.rncId).NotNull().WithMessage("The {PropertyName} cant be null");

        RuleFor(x => x.personTypeName).NotEmpty().WithMessage("The {PropertyName} cant be empty");

        RuleFor(x => x.personTypeName).NotNull().WithMessage("The {PropertyName} cant be null");

        RuleFor(x => x.name).NotEmpty().WithMessage("The {PropertyName} cant be empty");

        RuleFor(x => x.name).NotNull().WithMessage("The {PropertyName} cant be null");

        RuleFor(x => x.status).NotEmpty().WithMessage("The {PropertyName} cant be empty");

        RuleFor(x => x.status).NotNull().WithMessage("The {PropertyName} cant be null");
    }
}
