using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Posts.Application.Contracts;
using Posts.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Posts.Persistence
{
    public static class PersistenceDependency 
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<PostDBContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("PostConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>),typeof( BaseRepository<>));
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }

    }
}
