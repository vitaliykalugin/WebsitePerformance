using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace WebsitePerformance.Services
{
    public sealed class XmlSitemapHandler : BaseSitemapHandler
    {
        public XmlSitemapHandler(IHttpClientFactory clientFactory) : base(clientFactory) { }

        protected override string SitemapName
        {
            get
            {
                return Constants.XmlSitemapName;
            }
        }

        protected override async Task<IEnumerable<Uri>> ReadResponseAsync(HttpResponseMessage response)
        {
            using var stream = await response.Content.ReadAsStreamAsync();

            var xml = new XmlDocument();
            xml.Load(stream);

            return xml.GetElementsByTagName(Constants.XmlUriTagName)
                        .Cast<XmlNode>()
                        .Select(node => new Uri(node.InnerText))
                        .ToList();
        }
    }
}
