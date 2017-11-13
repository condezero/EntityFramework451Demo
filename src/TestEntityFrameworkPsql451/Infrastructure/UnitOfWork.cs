using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TestEntityFrameworkPsql451.Domain;
using TestEntityFrameworkPsql451.Models;

namespace TestEntityFrameworkPsql451.Infrastructure
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {

        private RoutingContext context = new RoutingContext();
        private IRepository<HubComponent> _hubComponentRepository;
        public IRepository<HubComponent> HubComponentRepository
        {
            get
            {
                if (_hubComponentRepository == null)
                {
                    _hubComponentRepository = new HubComponentRepository(context);
                }
                return _hubComponentRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public Task SaveAsync()
        {
           return context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}