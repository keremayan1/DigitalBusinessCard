using Core.Persistance.Repositories;
using IBANAccount.API.Domain.Entities;

namespace IBANAccount.API.Application.Services.Repositories
{
    public interface IIbanImageRepository : IAsyncRepository<IbanImage>, IRepository<IbanImage>
    {
    }
}
