using Microsoft.EntityFrameworkCore;
using OutLoud_Test.DataAccess.Entities;
using OutLoud_Test.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OutLoud_Test.DataAccess.Repositories
{
    public class FeedRepository : GenericRepository<Feed>, IFeedRepository
    {
        private readonly AppDbContext _db;

        public FeedRepository(AppDbContext db, AppDbContext context) : base(context) => 
            _db = db;

        public async Task<List<Feed>> GetAllActive() =>
            await _db.Feeds.Where(x => x.IsActive).ToListAsync();
    }
}
