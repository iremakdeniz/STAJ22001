using EducationPortal.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Domain.Entities
{
    public class Notification:EntityBase
    {
      
       
        public string Message { get; set; }
        public Guid UserId { get; set; }
        public ICollection<User> Users { get; set; }
    }
}

