using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestEntityFrameworkPsql451.Domain;
using TestEntityFrameworkPsql451.Models;

namespace TestEntityFrameworkPsql451.Infrastructure
{
    public class HubComponentRepository : IRepository<HubComponent>, IDisposable
    {
        private RoutingContext ctx;

        public HubComponentRepository(RoutingContext c)
        {
            ctx = c;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<HubComponent>> Get()
        {
            return await ctx.HubComponents.ToListAsync().ConfigureAwait(false);
        }

        public Task<HubComponent> Get(int id)
        {
            return ctx.HubComponents.FirstOrDefaultAsync(p => p.id_component == id);
        }

      
    }
}