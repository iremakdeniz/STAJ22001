using EducationPortal.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Domain.Entities
{
    public class TrainingCategory:EntityBase
    {
        
        public string Name { get; set; }
        public ICollection<Training> Trainings { get; set; }
        public bool IsDeleted { get; set; }
    }
}
