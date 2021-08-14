using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorClassLibrary.Models
{
    public class UserLoginNotification
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string TextNotification { get; set; }
    }
}
