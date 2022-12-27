using OutLoud_Test.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutLoud_Test.DataAccess.Repositories.Interfaces
{
    public interface IFeedRepository : IGenericRepository<Feed>
    {
        public Task<List<Feed>> GetAllActive();
    }
}
