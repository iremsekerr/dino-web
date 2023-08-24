using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DinoWebProject.Models.HomeViewModel
{
    public class Class
    {
        public IEnumerable <Contents> Contents { get; set; }
        public IEnumerable<News> News { get; set; }
        public IEnumerable<Sector> Sectors { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Support> Supports { get; set; }
    }
}