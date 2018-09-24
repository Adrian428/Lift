using System.Reflection;
using Autofac;
using MongoDB.Driver;
using Lift.Infrastructure.MongoDB;
using Lift.Infrastructure.Repositories;


namespace Lift.Infrastructure.IoC.Modules
{
    public class MongoDBModule : Autofac.Module
    {   
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c,p) =>
            {
                var settings = c.Resolve<MongoDBSettings>();

                return new MongoClient(settings.ConnectionString);

            }).SingleInstance();

            builder.Register((c,p) =>
            {
                var client = c.Resolve<MongoClient>();
                var settings = c.Resolve<MongoDBSettings>();
                var database = client.GetDatabase(settings.Database);


                return database;
            }).As<IMongoDatabase>();

            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(x=> x.IsAssignableTo<IMongoUserRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }
        
    }
}