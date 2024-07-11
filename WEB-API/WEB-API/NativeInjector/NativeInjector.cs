using WEB_API.Models;
using WEB_API.Repository;
using WEB_API.Services.TasksService;
using WEB_API.Services.UserService;

namespace WEB_API.NativeInjector
{
    public class NativeInjector
    {
        /// <summary>
        /// This method will be responsible to configure the dependency injections for every service class add on this project.
        /// </summary>
        /// <param name="services">Service collection received when the startup is executed</param>
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<ITasksService, TasksService>();
            services.AddScoped<IUserService, UserService>();


            #endregion Services

            #region Repositories

            services.AddScoped<IRepository<Tasks>, Repository<Tasks>>();
            services.AddScoped<IRepository<User>, Repository<User>>();

            #endregion Repositories
        }
    }
}
