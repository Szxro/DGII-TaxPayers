using FluentValidation;

namespace DGII_Taxpayers.Application.TaxReceipts.Query.GetAllTaxReceiptByRncIdQuery;

public class GetAllTaxReceiptByRncIdQueryValidator : AbstractValidator<GetAllTaxReceiptByRncIdQuery>
{
    public GetAllTaxReceiptByRncIdQueryValidator()
    {
        RuleFor(x => x.rncId).NotEmpty().WithMessage("The {PropertyName} cant be empty");

        RuleFor(x => x.rncId).NotNull().WithMessage("The {PropertyName} cant be null");
    }
}
