using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.ViewModel.Product
{
    public class DetailsViewModel
    {
        public ShowCase.Models.Product Product { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
