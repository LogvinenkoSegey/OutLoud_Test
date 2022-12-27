using Microsoft.AspNetCore.Mvc;
using OutLoud_Test.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutLoud_Test.BusinessLogic.Services.Interfaces
{
    public interface INewsService
    {
        public Task<List<News>> GetUnreadNewsFromDate(DateTime fromDate);
        public Task<IActionResult> SetNewsAsRead(List<News> news);
    }
}
