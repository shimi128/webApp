using Umbraco.Core.Models;

namespace WebTest.Domains
{
    public class ContentModel
    {
        public int NodeId { get; set; }
        public PropertyCollection Properties { get; set; }

        public string Name { get; set; }
    }
}