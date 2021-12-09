using oData.Core.Entities;
using Simple.OData.Client;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace oData.Client.Test
{
    public class TypedTests
    {
        static Uri _serviceUri = new("https://services.odata.org/v4/TripPinServiceRW/");
        ODataClient client = new(CreateDefaultSettings());
        public TypedTests()
        {

        }

        [Fact]
        public async Task Step1()
        {
            var people = await client
                .For<People>()
                .FindEntriesAsync();
            Assert.Equal(8, people.Count());
        }

        [Fact]
        public async Task Step1_WithAnnotations()
        {
            var annotations = new ODataFeedAnnotations();
            var count = 0;
            var people = await client
                .For<People>()
                .FindEntriesAsync(annotations);
            count += people.Count();
            while (annotations.NextPageLink != null)
            {
                people = await client
                    .For<People>()
                    .FindEntriesAsync(annotations.NextPageLink, annotations);
                count += people.Count();
            }
            Assert.Equal(20, count);
        }

        [Fact]
        public async Task Step2_Return_Specific_People()
        {
            var person = await client
                .For<People>()
                .Key("russellwhyte")
                .FindEntryAsync();
            Assert.Equal("russellwhyte", person.UserName);
        }

        [Fact]
        public async Task Step3_Filter_Top_Count()
        {
            var people = await client
                .For<People>()
                .Filter(x => x.Trips.Any(y => y.Budget > 3000))
                .Top(2)
                .Select(x => new { x.FirstName, x.LastName })
                .FindEntriesAsync();
            Assert.Equal(2, people.Count());
        }

        [Fact]
        public async Task Step4_Create_New_People()
        {
            var person = await client
                .For<People>()
                .Set(new People()
                {
                    UserName = "Ali",
                    FirstName = "Ali",
                    LastName = "Haghighi",
                    Emails = new[] { "contact@alihaghighi.pro" },
                    AddressInfo = new[]
                    {
                        new Location()
                        {
                            Address = "187 Suffolk Ln.",
                            City = new City
                            {
                                CountryRegion = "United States",
                                Name = "Boise",
                                Region = "ID"
                            }
                        }
                    },
                    Gender = PersonGender.Male,
                    Concurrency = 635519729375200400
                })
                .InsertEntryAsync();
            Assert.NotNull(person);
        }

        [Fact]
        public async Task Step5_Link_Trip()
        {
            var trip = await client
                .For<People>()
                .Key("russellwhyte")
                .NavigateTo<Trip>()
                .Key(0)
                .FindEntryAsync();
            await client
                .For<People>()
                .Key("scottketchum")
                .LinkEntryAsync(trip);
            var person = await client
                .For<People>()
                .Key("scottketchum")
                .Expand(x => x.Trips)
                .FindEntryAsync();
            Assert.True(person.Trips.Any(x => x.Name == trip.Name));
        }

        [Fact]
        public async Task Step6_Involved_Peopple_Count()
        {
            var people = await client
                .For<People>()
                .Key("scottketchum")
                .NavigateTo<Trip>()
                .Key(0)
                .Function("GetInvolvedPeople")
                .ExecuteAsEnumerableAsync();
            Assert.Equal(2, people.Count());
        }
        public static ODataClientSettings CreateDefaultSettings()
        {
            return new ODataClientSettings
            {
                BaseUri = _serviceUri,
                OnTrace = (x, y) => Console.WriteLine(string.Format(x, y)),
            };
        }
        static string GetMetadataDocument()
        {
            return "metadata.xml";
        }

    }
}