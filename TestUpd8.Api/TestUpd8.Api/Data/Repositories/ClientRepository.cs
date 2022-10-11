using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestUpd8.Api.Contracts;
using TestUpd8.Api.Data.Context;
using TestUpd8.Api.Entities;

namespace TestUpd8.Api.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataBaseContext _context;

        public ClientRepository(DataBaseContext context)
        {
            _context = context;
        }

        public async ValueTask AddAsync(Client client)
        {
            await _context.clients.AddAsync(client);
        }

        public async ValueTask<Client> FindByIdAsync(Guid id)
        {
            return await _context.clients.FindAsync(id);
        }

        public async ValueTask<IList<Client>> FindAllAsNoTrackingAsync()
        {
            return await _context.clients.ToListAsync();
        }

        public void Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
        }

        public void Delete(Client client)
        {
            _context.clients.Remove(client);
        }

        public async ValueTask<bool> AnyAsync(Expression<Func<Client, bool>> predicate)
        {
            return await _context.clients.AnyAsync(predicate);
        }

        public async ValueTask SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
