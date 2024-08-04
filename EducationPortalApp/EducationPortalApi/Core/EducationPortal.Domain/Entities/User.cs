using EducationPortal.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Domain.Entities
{
    public class User:EntityBase
    {
        public Guid ManagerId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Password{ get; set; }
        public Guid? TeamId { get; set; }
        public Team Team { get; set; }
        public ICollection<Training> Trainings { get; set; }
        public bool IsDeleted { get; set; }

        public string UserType { get; set; }
        
    }
}
