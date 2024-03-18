namespace DGII_Taxpayers.Domain.DTOs;

public sealed class TaxPayerDTO
{
    public string RncID { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;
}
