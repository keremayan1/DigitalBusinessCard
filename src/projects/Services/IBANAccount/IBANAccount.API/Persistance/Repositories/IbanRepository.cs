using Core.Persistance.Repositories.EntityFramework;
using IBANAccount.API.Application.Services.Repositories;
using IBANAccount.API.Domain.Entities;
using IBANAccount.API.Persistance.Contexts;

namespace IBANAccount.API.Persistance.Repositories
{
    public class IbanRepository : EfRepositoryBase<Iban, SQLContext>, IIbanRepository
    {
        public IbanRepository(SQLContext context) : base(context)
        {
        }
    }
}
