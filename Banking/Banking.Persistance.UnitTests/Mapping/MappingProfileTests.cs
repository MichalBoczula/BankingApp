using AutoMapper;
using Banking.Persistance.Profiles.Queries;

namespace Banking.Persistance.UnitTests.Mapping
{
    [TestFixture]
    public class MappingProfileTests
    {
        [Test]
        public void QueriesConfigurationIsValid()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<QueriesMappingProfiles>();
            });

            config.AssertConfigurationIsValid();
        }
    }
}
