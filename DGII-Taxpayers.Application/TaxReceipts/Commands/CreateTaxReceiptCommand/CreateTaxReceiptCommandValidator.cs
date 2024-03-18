using FluentValidation;

namespace DGII_Taxpayers.Application.TaxReceipts.Commands.CreateTaxReceiptCommand;

public class CreateTaxReceiptCommandValidator : AbstractValidator<CreateTaxReceiptCommand>
{
    public CreateTaxReceiptCommandValidator()
    {
        RuleFor(x => x.rncId).NotEmpty().WithMessage("The {PropertyName} cant be empty");

        RuleFor(x => x.rncId).NotNull().WithMessage("The {PropertyName} cant be null");

        RuleFor(x => x.ncf).NotEmpty().WithMessage("The {PropertyName} cant be empty");

        RuleFor(x => x.ncf).NotNull().WithMessage("The {PropertyName} cant be null");

        RuleFor(x => x.amount).NotEmpty().WithMessage("The {PropertyName} cant be empty");

        RuleFor(x => x.amount).NotNull().WithMessage("The {PropertyName} cant be null");

        RuleFor(x => x.amount).Must(x => double.TryParse(x, out _))
                              .When(x => !string.IsNullOrEmpty(x.amount))
                              .WithMessage("The {PropertyName} is invalid, check and try again");
    }
}
