using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterstPage.Models
{
    public class InterstModel
    {
        public List<PhotoModel> MyInterstsList { get; set; }
        public List<RssItem> RssItems { get; set; } = new List<RssItem>();
    }
}
