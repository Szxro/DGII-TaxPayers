using DGII_Taxpayers.Domain.Contracts;
using DGII_Taxpayers.Domain.Entitites;
using DGII_Taxpayers.Infrastructure.Common;
using DGII_Taxpayers.Infrastructure.Persistence;

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
}
