using FluentValidation;

namespace DGII_Taxpayers.Application.TaxPayers.Commands.CreateTaxPayerCommand;

public class CreateTaxPayerCommandValidator : AbstractValidator<CreateTaxPayerCommand>
{
    public CreateTaxPayerCommandValidator()
    {
        RuleFor(x => x.rncId).NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacio");

        RuleFor(x => x.rncId).NotNull().WithMessage("El campo {PropertyName} no puede estar nulo");

        RuleFor(x => x.personTypeName).NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacio");

        RuleFor(x => x.personTypeName).NotNull().WithMessage("El campo {PropertyName} no puede estar nulo");

        RuleFor(x => x.name).NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacio");

        RuleFor(x => x.name).NotNull().WithMessage("El campo {PropertyName} no puede estar nulo");

        RuleFor(x => x.status).NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacio");

        RuleFor(x => x.status).NotNull().WithMessage("El campo {PropertyName} no puede estar nulo");
    }
}
