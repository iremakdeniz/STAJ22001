using EducationPortal.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Domain.Entities
{
    public class Team:EntityBase
    {
     
        public string Name { get; set; }
        public Guid? ManagerId { get; set; }
        [NotMapped]
        public User Manager { get; set; }
        public ICollection<User> Members { get; set; }
    }
}
