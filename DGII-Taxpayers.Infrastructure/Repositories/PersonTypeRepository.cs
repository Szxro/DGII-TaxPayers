using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.DTOs;
using DGII_Taxpayers.Domain.Entitites;
using DGII_Taxpayers.Domain.Events.PersonType;
using DGII_Taxpayers.Infrastructure.Common;
using DGII_Taxpayers.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DGII_Taxpayers.Infrastructure.Repositories;

public class PersonTypeRepository 
    : GenericRepository<PersonType>, IPersonTypeRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public PersonTypeRepository(AppDbContext dbContext,
                                IUnitOfWork unitOfWork) : base(dbContext)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task AddDefaultPersonType()
    {
        ICollection<PersonType> personTypes = new HashSet<PersonType>()
        {
            new PersonType(){TypeName = "PERSONA JURIDICA" },
            new PersonType(){TypeName = "PERSONA FISICA" },
        };

        AddRange(personTypes);

        await _unitOfWork.SaveChangesAsync();
    }

    public void CreatePersonType(string typeName)
    {
        PersonType personType = new PersonType()
        {
            TypeName = typeName,
        };

        Add(personType);

        personType.AddEvent(new PersonTypeCreateEvent(typeName));
    }

    public async Task<List<PersonTypeDTO>> GetAllPersonType()
    {
        return await _dbContext.PersonType.Select(x => new PersonTypeDTO() { TypeName = x.TypeName }).ToListAsync();
    }

    public async Task<PersonType?> GetPersonTypeByTypeName(string typeName)
    {
        return await _dbContext.PersonType.AsNoTracking().FirstOrDefaultAsync(x => x.TypeName == typeName); 
    }

    public async Task<bool> IsPersonTypeNameFound(string typeName)
    {
        return await _dbContext.PersonType.AnyAsync(x => x.TypeName == typeName);
    }
}
