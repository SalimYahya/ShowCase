using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.ViewModel.Role
{
    public class EditViewModel
    {
        public string Id { get; set; }
        
        [Required(ErrorMessage ="Role Name Required")]
        public string RoleName { get; set; }

        public List<ApplicationUser> Users { get; set; }
    }
}
