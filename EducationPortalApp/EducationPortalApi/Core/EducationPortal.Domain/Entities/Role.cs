using EducationPortal.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Domain.Entities
{
    public class Role:EntityBase
    {
       
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
        public bool IsDeleted { get; set; }
    }
}
