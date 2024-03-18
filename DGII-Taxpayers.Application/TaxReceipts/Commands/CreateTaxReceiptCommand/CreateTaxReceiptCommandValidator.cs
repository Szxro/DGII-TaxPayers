using FluentValidation;

namespace DGII_Taxpayers.Application.TaxReceipts.Commands.CreateTaxReceiptCommand;

public class CreateTaxReceiptCommandValidator : AbstractValidator<CreateTaxReceiptCommand>
{
    public CreateTaxReceiptCommandValidator()
    {
        RuleFor(x => x.rncId).NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacio");

        RuleFor(x => x.rncId).NotNull().WithMessage("El campo {PropertyName} no puede estar nulo");

        RuleFor(x => x.ncf).NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacio");

        RuleFor(x => x.ncf).NotNull().WithMessage("El campo {PropertyName} no puede estar nulo");

        RuleFor(x => x.amount).NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacio");

        RuleFor(x => x.amount).NotNull().WithMessage("El campo {PropertyName} no puede estar nulo");

        RuleFor(x => x.amount).Must(x => double.TryParse(x, out _))
                              .When(x => !string.IsNullOrEmpty(x.amount))
                              .WithMessage("El campo {PropertyName} es invalido, compruebe e intenta de nuevo");
    }
}
