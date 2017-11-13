using System.Threading.Tasks;
using TestEntityFrameworkPsql451.Domain;
using TestEntityFrameworkPsql451.Models;

namespace TestEntityFrameworkPsql451.Infrastructure
{
    public interface IUnitOfWork
    {
        IRepository<HubComponent> HubComponentRepository { get; }

        void Save();
        Task SaveAsync();
    }
}