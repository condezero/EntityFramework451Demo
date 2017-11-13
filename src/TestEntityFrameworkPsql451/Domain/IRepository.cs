using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestEntityFrameworkPsql451.Domain
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> Get(int id);

    }
}