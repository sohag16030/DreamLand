
//using Domain.Core.Bus;
//using MicroRabbit.Infra.Bus;
using DBFirst.IRepository;
using DBFirst.Repository;
using Microsoft.Extensions.DependencyInjection;


namespace DBFirst
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddTransient<IUser, User>();
            services.AddTransient<IPost, Post>();
            services.AddTransient<ILike, Like>();
            services.AddTransient<IComment, Comment>();

        }
    }
}
