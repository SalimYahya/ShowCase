using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.ViewModel.Profile
{
    public class ProfileEditUserViewModel
    {
        public ApplicationUser User { get; set; }
        public Address Address { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
