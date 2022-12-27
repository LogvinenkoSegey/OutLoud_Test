using Microsoft.AspNetCore.Mvc;
using OutLoud_Test.BusinessLogic.Services.Interfaces;
using OutLoud_Test.DataAccess.Entities;
using OutLoud_Test.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;

namespace OutLoud_Test.BusinessLogic.Services
{
    public class FeedService : IFeedService
    {
        private readonly IFeedRepository _feedRepository;

        public FeedService(IFeedRepository feedRepository) =>
            _feedRepository = feedRepository;

        public async Task<IActionResult> Add(string URL)
        {
            using var reader = XmlReader.Create(URL);
            var syndicationFeed = SyndicationFeed.Load(reader);
            var feed = new Feed
            {
                IsActive = true,
                Title = syndicationFeed.Title.Text,
                Description = syndicationFeed.Description.Text,
                URL = URL
            };

            await _feedRepository.Create(feed);

            return new JsonResult("Feed was added succsessfully");
        }

        public async Task<List<Feed>> GetAllActive() =>
            (await _feedRepository.GetAllActive()).ToList();
    }
}
