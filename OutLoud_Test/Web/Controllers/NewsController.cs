using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutLoud_Test.BusinessLogic.Services.Interfaces;
using OutLoud_Test.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OutLoud_Test.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService) =>
            _newsService = newsService;

        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetUnreadNewsFromDate(DateTime fromDate) =>
            Ok(await _newsService.GetUnreadNewsFromDate(fromDate));

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> SetNewsAsRead(List<News> news) =>
            Ok(await _newsService.SetNewsAsRead(news));
    }
}