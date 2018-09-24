using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;

namespace Lift.Infrastructure.MongoDB
{
    public static class MongoDBConfigurator
    {
        private static bool _initialized;
        public static void Initialize()
        {
            if(_initialized)
            {
                return;
            }
        }

        private static void RegisterConventions()
        {
            ConventionRegistry.Register("LiftConventions", new MongoConvention(), x => true);
        }

        private class MongoConvention : IConventionPack
        {
            public IEnumerable<IConvention> Conventions => new List<IConvention>
            {
                new IgnoreExtraElementsConvention(true),
                new EnumRepresentationConvention(BsonType.String),
                new CamelCaseElementNameConvention(),
            };
        }
    }
}