using System.Spatial;

namespace oData.Core.Entities
{
    public enum PersonGender
    {
        Male,
        Female,
        Unknown,
    }

    public class Person
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Emails { get; set; }
        public Location[] AddressInfo { get; set; }
        public PersonGender Gender { get; set; }
        public long Concurrency { get; set; }

        public IEnumerable<Person> Friends { get; set; }
        public IEnumerable<Trip> Trips { get; set; }
        public IEnumerable<Photo> Photos { get; set; }
    }

    public class People : Person
    {
    }

    public class Trip
    {
        public int TripId { get; set; }
        public Guid ShareId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public float Budget { get; set; }
        public DateTimeOffset StartsAt { get; set; }
        public DateTimeOffset EndsAt { get; set; }
        public IList<string> Tags { get; set; }

        public IEnumerable<Photo> Photos { get; set; }
        public IEnumerable<PlanItem> PlanItems { get; set; }
    }

    public class Photo
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class PlanItem
    {
        public int PlanItemId { get; set; }
        public string ConfirmationCode { get; set; }
        public DateTimeOffset StartsAt { get; set; }
        public DateTimeOffset EndsAt { get; set; }
        public TimeSpan Duration { get; set; }
    }

    public class PublicTransportation : PlanItem
    {
        public string SeatNumber { get; set; }
    }

    public class Flight : PublicTransportation
    {
        public string FlightNumber { get; set; }
        public Airport From { get; set; }
        public Airport To { get; set; }
        public Airline Airline { get; set; }
    }

    public class Event : PlanItem
    {
        public string Description { get; set; }
        public EventLocation OccursAt { get; set; }
    }

    public class Airline
    {
        public string AirlineCode { get; set; }
        public string Name { get; set; }
    }

    public class Airport
    {
        public string IcaoCode { get; set; }
        public string IataCode { get; set; }
        public string Name { get; set; }
        public AirportLocation Location { get; set; }
    }

    public class City
    {
        public string CountryRegion { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
    }

    public class Location
    {
        public string Address { get; set; }
        public City City { get; set; }
    }

    public class AirportLocation : Location
    {
        public GeographyPoint Loc { get; set; }
    }

    public class EventLocation : Location
    {
        public string BuildingInfo { get; set; }
    }
}
