using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspCore.Models.ViewModels
{
    public class UserGroupVM
    {
        public UserGroup? UserGroup { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> UserList { get; set; }
    }
}
