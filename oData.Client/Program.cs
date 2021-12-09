using Newtonsoft.Json;
using oData.Core.Entities;
using Simple.OData.Client;

Uri _serviceUri = new Uri("https://services.odata.org/v4/TripPinServiceRW/");
var client = new ODataClient(CreateDefaultSettings());

await TypedFluentClient(client);
await GetTripsInfo(client, "scottketchum");

Console.ReadKey();


static async Task TypedFluentClient(ODataClient client)
{
    var Peoples = await client
        .For<People>()
        //.Key("russellwhyte")
        .Filter(x => x.Trips.Any(y => y.Budget > 3000))
        //.Top(2)
        .Select(x => new { x.FirstName, x.LastName })
        .FindEntriesAsync();

    foreach (var people in Peoples)
    {
        Console.WriteLine(people.LastName);
    }
}

static async Task CreatePeople(ODataClient client)
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

}

static async Task<People> GetUser_TripsInfo(ODataClient client)
{
    return await client
                .For<People>()
                .Key("scottketchum")
                .Expand(x => x.Trips)
                .FindEntryAsync();
}

static async Task GetTripsInfo(ODataClient client, string keyQuery)
{
    var people = await client
                .For<People>()
                .Key(keyQuery)
                .Expand(x => x.Trips)
                .FindEntryAsync();
    var Trips = people.Trips;
    
    Console.WriteLine(Environment.NewLine + "********************************************");
    Console.WriteLine($"Passenger: {people.FirstName} {people.LastName}" + Environment.NewLine + "----------------");
    foreach (var trip in Trips)
    {
        Console.WriteLine($"{trip.Name} \r\n Start: {trip.StartsAt} \r\n End: {trip.EndsAt}");
        Console.WriteLine("------------------------------------");
    }
}

ODataClientSettings CreateDefaultSettings()
{
    return new ODataClientSettings
    {
        BaseUri = _serviceUri,
        OnTrace = (x, y) => Console.WriteLine(string.Format(x, y)),
    };
}
string GetMetadataDocument()
{
    return "metadata.xml";
}

