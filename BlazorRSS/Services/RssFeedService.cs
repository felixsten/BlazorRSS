using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
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

        public async Task<List<RssFeedItem>> GetRssFeedAsync(string feedUrl)
        {
            try
            {
                using var response = await _httpClient.GetAsync(feedUrl);
                response.EnsureSuccessStatusCode();
                var stream = await response.Content.ReadAsStreamAsync();

                using var reader = XmlReader.Create(stream);
                var feed = SyndicationFeed.Load(reader);

                return feed?.Items.Select(item => new RssFeedItem
                {
                    Title = item.Title.Text,
                    Summary = item.Summary?.Text,
                    PublishDate = item.PublishDate.DateTime,
                    Link = item.Links.FirstOrDefault()?.Uri.ToString(),
                    ImageUrl = GetImageUrl(item), 
                    Description = item.ElementExtensions
                        .FirstOrDefault(e => e.OuterName == "description")?.GetObject<XmlElement>()?.InnerText 
                }).ToList() ?? new List<RssFeedItem>();
            }
            catch (Exception)
            {
                return new List<RssFeedItem>();
            }
        }

        private string GetImageUrl(SyndicationItem item)
        {
            var imageUrl = item.ElementExtensions
                .FirstOrDefault(e => e.OuterName == "content" && e.OuterNamespace == "http://search.yahoo.com/mrss/")?
                .GetObject<XmlElement>()?.GetAttribute("url");

            if (string.IsNullOrEmpty(imageUrl))
            {
                imageUrl = item.Links.FirstOrDefault(link => link.RelationshipType == "enclosure" && link.MediaType.StartsWith("image"))?.Uri.ToString();
            }

            return imageUrl;
        }
    }

    
    public class RssFeedItem
    {
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Link { get; set; }
        public DateTime PublishDate { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}