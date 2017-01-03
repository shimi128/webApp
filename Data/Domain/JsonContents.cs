using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Domain
{
    public class JsonContents:BaseEntity
    {
        public int NodeId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
