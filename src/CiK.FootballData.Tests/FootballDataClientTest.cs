using System;
using System.Linq;
using Newtonsoft.Json;
using Xunit;

namespace CiK.FootballData.Tests
{
    public class FootballDataClientTest
    {
        [Fact]
        public void CanGetCompetitionsBySeason()
        {
            var client = new FootballDataClient(Protocol.HTTP, "acec24061235402a802ad04c9f7b6b81");
            var competionsBy2016Season = client.GetSeasonsAsync("2016").Result;

            // only for information
            Console.WriteLine(JsonConvert.SerializeObject(competionsBy2016Season));

            Assert.NotNull(competionsBy2016Season);
            Assert.True(competionsBy2016Season.Any());
        }
    }
}