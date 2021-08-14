using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class EmailBase
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Text { get; set; }
    }
}
