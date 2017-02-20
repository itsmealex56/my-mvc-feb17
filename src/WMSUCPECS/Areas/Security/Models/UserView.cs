using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMSUCPECS.Areas.Security.Models
{
    public class UserView
    {
        public Guid Id  { get; set; }

        [Required, Display (Name = "FIRST NAME")]
        [MinLength(2, ErrorMessage = "Minimum of 2 Characters")]
        [MaxLength(15, ErrorMessage = "Maximum of 15 Characters")]
        public String FirstName { get; set; }

        [Required, Display(Name = "LAST NAME")]
        [MinLength(2, ErrorMessage = "Minimum of 2 Characters")]
        [MaxLength(15, ErrorMessage = "Maximum of 15 Characters")]
        public String LastName { get; set; }

        [Range(1,100)]
        public int? Age { get; set; }

        public String Gender { get; set; }




    }

}