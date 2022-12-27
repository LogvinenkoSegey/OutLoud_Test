using Microsoft.AspNetCore.Mvc;
using OutLoud_Test.BusinessLogic.Services.Interfaces;
using OutLoud_Test.DataAccess.Entities;
using OutLoud_Test.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutLoud_Test.BusinessLogic.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository) =>
            _newsRepository = newsRepository;

        public async Task<List<News>> GetUnreadNewsFromDate(DateTime fromDate) =>
            await _newsRepository.GetUnreadNewsFromDate(fromDate);

        public async Task<IActionResult> SetNewsAsRead(List<News> news)
        {
            await _newsRepository.SetNewsAsRead(news);

            return new JsonResult("News were set as read succsessfully!");
        }
    }
}
