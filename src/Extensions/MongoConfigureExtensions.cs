using dito.Core.Mongo;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace dito.Extensions
{

    public static class MongoConfigureExtensions
    {
        public static IApplicationBuilder UseMongodatabase(this IApplicationBuilder app, IConfiguration configuration)
        {
            new MongoDatabaseConfiguration(configuration).Configure();
            return app;
        }
    }

}