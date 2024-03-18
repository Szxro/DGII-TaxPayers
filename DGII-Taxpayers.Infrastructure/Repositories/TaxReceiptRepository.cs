using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.DTOs;
using DGII_Taxpayers.Domain.Entitites;
using DGII_Taxpayers.Domain.Events.TaxReceipt;
using DGII_Taxpayers.Infrastructure.Common;
using DGII_Taxpayers.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DGII_Taxpayers.Infrastructure.Repositories;

public class TaxReceiptRepository : GenericRepository<TaxReceipt>, ITaxReceiptRepository
{
    public TaxReceiptRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public void CreateTaxReceipt(TaxPayer taxPayer,
                                 string ncf,
                                 string amount)
    {
        TaxReceipt taxReceipt = new TaxReceipt()
        {
            NCF = ncf,
            Amount = double.Parse(amount),
            Itbis18 = double.Parse(amount) * 0.18,
            TaxPayer = taxPayer
        };

        _dbContext.Entry(taxReceipt.TaxPayer).State = EntityState.Unchanged;

        Add(taxReceipt);

        taxReceipt.AddEvent(new TaxReceiptCreateEvent(taxPayer.RncID));
    }

    public async Task<List<TaxReceiptDTO>> GetAllTaxReceipt()
    {
        return await _dbContext.TaxReceipt.AsNoTracking()
                                          .Include(x => x.TaxPayer)
                                          .Select(x => new TaxReceiptDTO()
                                          {
                                              RncId = x.TaxPayer.RncID,
                                              NCF = x.NCF,
                                              Amount = x.Amount,
                                              Itbis18 = x.Itbis18
                                          })
                                          .ToListAsync();
    }

    public async Task<List<TaxReceiptDTO>> GetTaxReceiptsByRncId(string rncId)
    {
        return await _dbContext.TaxReceipt.AsNoTracking()
                                          .Include(x => x.TaxPayer)
                                          .Where(x => x.TaxPayer.RncID == rncId)
                                          .Select(x => new TaxReceiptDTO()
                                          {
                                              RncId = x.TaxPayer.RncID,
                                              NCF = x.NCF,
                                              Amount = x.Amount,
                                              Itbis18 = x.Itbis18
                                          })
                                          .ToListAsync();
    }

    public async Task<bool> IsNcfNotAvaliable(string ncf)
    {
        return await _dbContext.TaxReceipt.AnyAsync(x => x.NCF == ncf);
    }
}
