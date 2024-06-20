using LibraryManager.Core.Repositories;
using LibraryManager.Infrastructure.Persistence.Repositories;

namespace LibraryManager.API.Configurations
{
    public static class ServiceColletionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<ILoanRepository, ILoanRepository>();

            return services;
        }
    }
}
