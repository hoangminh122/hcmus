using HCMUS.src.Entities.Setting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCMUS.src.Modules.Database
{
    public static class RepositoryRegister
    {
        public static void AddMongoDbRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString
                 = configuration["MongoSettings:ConnectionString"];
                options.Database
                 = configuration["MongoSettings:Database"];
            });

            services.AddSingleton(typeof(IMongoRepository<,>), typeof(MongoRepository<,>));

        }

        public static void AddMongoDbRepository(this IServiceCollection services, string connectionString, string database)
        {
            services.Configure<MongoDbSettings>(options =>
            {
                options.ConnectionString = connectionString;
                options.Database = database;
            });

            services.AddSingleton(typeof(IMongoRepository<,>), typeof(MongoRepository<,>));
        }
    }
}
