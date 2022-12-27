using OutLoud_Test.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutLoud_Test.DataAccess.Repositories.Interfaces
{
    public interface INewsRepository : IGenericRepository<News>
    {
        public Task<List<News>> GetUnreadNewsFromDate(DateTime fromDate);
        public Task SetNewsAsRead(List<News> news);
    }
}
