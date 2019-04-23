using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JandC.Data
{
    public class Article
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public int ReadeTimes { get; set; }
    }
}
