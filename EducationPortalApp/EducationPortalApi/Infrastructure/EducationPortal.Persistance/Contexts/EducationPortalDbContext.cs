using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Entities.Common;
using EducationPortal.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Persistance.Contexts
{
    public class EducationPortalDbContext :DbContext
    {
        public EducationPortalDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<TrainingCategory> TrainingCategories { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<EntityBase>();
            foreach (var data in datas) 
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified=> data.Entity.UpdatedDate = DateTime.UtcNow,
                    _=>data.Entity.UpdatedDate
                };  
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
