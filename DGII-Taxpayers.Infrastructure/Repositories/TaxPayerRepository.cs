using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.DTOs;
using DGII_Taxpayers.Domain.Entitites;
using DGII_Taxpayers.Domain.Events.TaxPayer;
using DGII_Taxpayers.Infrastructure.Common;
using DGII_Taxpayers.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DGII_Taxpayers.Infrastructure.Repositories;

public class TaxPayerRepository
    : GenericRepository<TaxPayer>, ITaxPayerRepository
{
    public TaxPayerRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }

    public void CreateTaxPayerAsync(string rncId,
                                    string name,
                                    PersonType personType,
                                    string status)
    {
        TaxPayer newTaxPayer = new TaxPayer()
        {
            RncID = rncId,
            Name = name,
            PersonType = personType,
            Status = status
        };

        _dbContext.Entry(newTaxPayer.PersonType).State = EntityState.Unchanged;

        Add(newTaxPayer);

        newTaxPayer.AddEvent(new TaxPayerCreateEvent(newTaxPayer.RncID));
    }

    public async Task<List<TaxPayerDTO>> GetAllTaxPayer()
    {
        return await _dbContext.TaxPayer.AsNoTracking()
                                        .Include(payer => payer.PersonType)
                                        .Select(payer => new TaxPayerDTO()
                                        {
                                            RncID = payer.RncID,
                                            Name = payer.Name,
                                            Status = payer.Status,
                                            Type = payer.PersonType.TypeName
                                        })
                                        .ToListAsync();
    }

    public async Task<TaxPayer?> GetTaxPayerByRncId(string rncId)
    {
        return await _dbContext.TaxPayer.AsNoTracking().FirstOrDefaultAsync(x => x.RncID == rncId);
    }

    public async Task<bool> IsTaxPayerRncIdNotAvaliable(string rncID)
    {
        return await _dbContext.TaxPayer.AnyAsync(x => x.RncID == rncID);
    }
}
