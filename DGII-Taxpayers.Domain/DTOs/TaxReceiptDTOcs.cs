namespace DGII_Taxpayers.Domain.DTOs;

public sealed class TaxReceiptDTO
{
    public string RncId { get; set; } = string.Empty;

    public string NCF { get; set; } = string.Empty;

    public double Amount { get; set; } 

    public double Itbis18 { get; set; } 
}
