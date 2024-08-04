using EducationPortal.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EducationPortal.Application.Repositories;
using EducationPortal.Domain.Entities.Identity;
using EducationPortal.Persistance.Repositories;
using EducationPortal.Application.Services;
using EducationPortal.Persistance.Services;

namespace EducationPortal.Persistance
{
    public static class ServiceRegistration
    {
      public static void AddPersistanceServices(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<EducationPortalDbContext>(options => options.UseNpgsql(connectionString));
            services.AddScoped<IUserReadRepository,UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();
            services.AddScoped<ITrainingReadRepository, TrainingReadRepository>();
            services.AddScoped<ITrainingWriteRepository, TrainingWriteRepository>();
            services.AddScoped<IRoleReadRepository, RoleReadRepository>();
            services.AddScoped<IRoleWriteRepository, RoleWriteRepository>();
            services.AddScoped<ITrainingCategoryReadRepository, TrainingCategoryReadRepository>();
            services.AddScoped<ITrainingCategoryWriteRepository, TrainingCategoryWriteRepository>();
            services.AddScoped<INotificationReadRepository, NotificationReadRepository>();
            services.AddScoped<INotificationWriteRepository, NotificationWriteRepository>();
            services.AddScoped<ITeamReadRepository, TeamReadRepository>();
            services.AddScoped<ITeamWriteRepository, TeamWriteRepository>();


        }      
    }
}
