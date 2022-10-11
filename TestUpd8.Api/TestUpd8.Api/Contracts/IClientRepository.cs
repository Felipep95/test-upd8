using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestUpd8.Api.Entities;

namespace TestUpd8.Api.Contracts
{
    public interface IClientRepository
    {
        ValueTask AddAsync(Client client);
        ValueTask<Client> FindByIdAsync(Guid id);
        ValueTask<IList<Client>> FindAllAsNoTrackingAsync();
        void Update(Client client);
        void Delete(Client client);
        ValueTask<bool> AnyAsync(Expression<Func<Client, bool>> predicate);
        ValueTask SaveChangesAsync();
    }
}
