using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.ViewModel.Profile
{
    public class UserInventoryModelView
    {
        public UserInventoryModelView()
        {
            ProductInventoryInfoList = new List<ProductInventoryInfo>();
        }
        public List<ProductInventoryInfo> ProductInventoryInfoList { get; set; }
    }
}
