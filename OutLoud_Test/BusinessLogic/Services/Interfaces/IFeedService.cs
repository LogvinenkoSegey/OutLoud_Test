using Microsoft.AspNetCore.Mvc;
using OutLoud_Test.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutLoud_Test.BusinessLogic.Services.Interfaces
{
    public interface IFeedService
    {
        public Task<IActionResult> Add(string URL);
        public Task<List<Feed>> GetAllActive();
    }
}
