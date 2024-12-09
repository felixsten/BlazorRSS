using System.ServiceModel.Syndication;
using System.Xml;

namespace BlazorRSS.Services
{
    public class RssFeedService
    {
        private readonly HttpClient _httpClient;

        public RssFeedService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SyndicationItem>> GetRssFeedAsync(string feedUrl = "https://www.sydsvenskan.se/feeds/feed.xml")
        {
            try
            {
                using var response = await _httpClient.GetAsync(feedUrl);
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();

                using var reader = XmlReader.Create(stream);
                var feed = SyndicationFeed.Load(reader);

                return feed?.Items.ToList() ?? new List<SyndicationItem>();
            }
            catch (Exception)
            {
                return new List<SyndicationItem>();
            }
        }
    }
}
