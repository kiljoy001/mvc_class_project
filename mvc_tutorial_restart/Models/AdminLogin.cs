using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvc_tutorial_restart.Models
{
    public class AdminLogin
    {   [Required(AllowEmptyStrings = false)]
        [Display(Name ="Username")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Secret { get; set; }

    }
}