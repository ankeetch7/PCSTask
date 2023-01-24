using DAL.DataContext;
using DAL.UOW;
using DAL.UOW.IUOW;
using DAL.ViewModels.Employee;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DALDependencyInjection
    {
        public static IServiceCollection AddDALDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicatiobDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<CreateEmployeeCommandValidator>();

            return services;
        }
    }
}
