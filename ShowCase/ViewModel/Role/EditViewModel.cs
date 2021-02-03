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
        public EditViewModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        
        [Required(ErrorMessage ="Role Name Required")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
