using Microsoft.Extensions.DependencyInjection;
using System;
using Vacations.API.Contexts;
using Vacations.API.Contracts.Repositories.Leaves;
using Vacations.API.Contracts.Repositories.Trainings;
using Vacations.API.Contracts.Repositories.WFH;
using Vacations.API.Contracts.Services.Leaves;
using Vacations.API.Contracts.Services.Trainings;
using Vacations.API.Contracts.Services.WFH;
using Vacations.API.Core.Repositories;
using Vacations.API.Core.Repositories.Leaves;
using Vacations.API.Core.Repositories.Trainings;
using Vacations.API.Core.Repositories.WFH;
using Vacations.API.Core.Services.Leaves;
using Vacations.API.Core.Services.Trainings;
using Vacations.API.Core.Services.WFH;

namespace Vacations.API.Extensions
{
    public static class ServiceExtension
    {
        public readonly static string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRespository<>));
            services.AddScoped<IDapperVacationContext, DapperVacationContext>();
            services.AddScoped<IEmployeeLeavesService, EmployeeLeavesService>();
            services.AddScoped<IEmployeeLeavesRepository, EmployeeLeavesRepository>();
            services.AddScoped<IEmployeeLeavesAddService, EmployeeLeavesAddService>();
            services.AddScoped<IEmployeeLeavesAddRepository, EmployeeLeavesAddRepository>();
            services.AddScoped<IEmployeeLeavesDeleteService, EmployeeLeavesDeleteService>();
            services.AddScoped<IEmployeeLeavesDeleteRepository, EmployeeLeavesDeleteRepository>();
            services.AddScoped<IEmployeeTrainingsService, EmployeeTrainingsService>();
            services.AddScoped<IEmployeeTrainingsRepository, EmployeeTrainingsRepository>();
            services.AddScoped<IEmployeeTrainingsAddService, EmployeeTrainingsAddService>();
            services.AddScoped<IEmployeeTrainingsAddRepository, EmployeeTrainingsAddRepository>();
            services.AddScoped<IEmployeeTrainingsDeleteService, EmployeeTrainingsDeleteService>();
            services.AddScoped<IEmployeeTrainingsDeleteRepository, EmployeeTrainingsDeleteRepository>();
            services.AddScoped<ITrainingTypeRepository, TrainingTypeRepository>();
            services.AddScoped<IEmployeeWFHService, EmployeeWFHService>();
            services.AddScoped<IEmployeeWFHRepository, EmployeeWFHRepository>();
            services.AddScoped<IEmployeeWFHUpdateService, EmployeeWFHUpdateService>();
            services.AddScoped<IEmployeeWFHUpdateRepository, EmployeeWFHUpdateRepository>();
            services.AddScoped<IEmployeeWFHDeleteService, EmployeeWFHDeleteService>();
            services.AddScoped<IEmployeeWFHDeleteRepository, EmployeeWFHDeleteRepository>();
            services.AddScoped<IEmployeeWFHDaysRepository, EmployeeWFHDaysRepository>();

            #endregion


/*            #region CORS
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .SetPreflightMaxAge(TimeSpan.FromSeconds(7200));
            }));

            #endregion

*/          
        }
    }
}
