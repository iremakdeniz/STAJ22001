using EducationPortal.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Domain.Entities
{
    public class Training:EntityBase
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public TrainingCategory Category { get; set; }
        public ICollection<User> Users { get; set; }
        public bool IsDeleted { get; set; }
    }
}
