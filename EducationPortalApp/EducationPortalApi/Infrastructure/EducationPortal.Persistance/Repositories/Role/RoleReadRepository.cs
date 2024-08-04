using EducationPortal.Application.Repositories;
using EducationPortal.Domain.Entities;
using EducationPortal.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Persistance.Repositories
{
    public class RoleReadRepository : ReadRepository<Role>, IRoleReadRepository
    {
        public RoleReadRepository(EducationPortalDbContext context) : base(context)
        {
        }
    }
}
