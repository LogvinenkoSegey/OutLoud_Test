using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutLoud_Test.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity item);
        Task<IEnumerable<TEntity>> GetAll();
        Task Remove(TEntity item);
        Task Remove(IEnumerable<TEntity> items);
        Task Update(TEntity item);
    }
}
