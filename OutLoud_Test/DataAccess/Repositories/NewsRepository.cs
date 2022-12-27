using Microsoft.EntityFrameworkCore;
using OutLoud_Test.DataAccess.Entities;
using OutLoud_Test.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutLoud_Test.DataAccess.Repositories
{
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        private readonly AppDbContext _db;

        public NewsRepository(AppDbContext db, AppDbContext context) : base(context) =>
            _db = db;

        public async Task<List<News>> GetUnreadNewsFromDate(DateTime fromDate) => 
            await _db.News.Where(x => !x.IsRead && fromDate >= x.NewsDate).ToListAsync();

        public async Task SetNewsAsRead(List<News> news)
        {
            _db.News.UpdateRange(news);
            await _db.SaveChangesAsync();
        }
    }
}
