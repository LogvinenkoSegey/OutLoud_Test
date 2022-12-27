using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OutLoud_Test.BusinessLogic.Services.Interfaces;
using OutLoud_Test.DataAccess.Entities;
using System.Threading.Tasks;

namespace OutLoud_Test.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IFeedService _feedService;

        public FeedController(IFeedService feedService) => 
            _feedService = feedService;

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> Add(string URL) =>
            Ok(await _feedService.Add(URL));

        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<IActionResult> GetAll() =>
            Ok(await _feedService.GetAllActive());
    }

}
