using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMSUCPECS.Dal
{
   public class User
    {
        public User()
        {
            Educations = new List<Education>();
        }
        [Key]
       public int Id { get; set; }
       public String FirstName { get; set; }
       public String LastName { get; set; }
       public int? Age { get; set; }
       public String Gender { get; set; }
       public DateTime? EmploymentDate { get; set; }

       public ICollection<Education> Educations { get; set; }
    }
}
