using FluentValidation;

namespace DGII_Taxpayers.Application.TaxReceipts.Query.GetAllTaxReceiptByRncIdQuery;

public class GetAllTaxReceiptByRncIdQueryValidator : AbstractValidator<GetAllTaxReceiptByRncIdQuery>
{
    public GetAllTaxReceiptByRncIdQueryValidator()
    {
        RuleFor(x => x.rncId).NotEmpty().WithMessage("El campo {PropertyName} no puede estar vacio");

        RuleFor(x => x.rncId).NotNull().WithMessage("El campo {PropertyName} no puede estar vacio");
    }
}
