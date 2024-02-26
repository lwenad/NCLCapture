
using Microsoft.VisualBasic;
using NCLCapture;
using System;
using System.Linq.Expressions;

Console.WriteLine("Let's start Search NCL cruise line price");

NclApiClient client = new NclApiClient();

 List<Vacation> vactions = await client.GetVcationItineraries();

List<Vacation> nycvactions = vactions.Where(x => (x.code.Contains("NYC"))
                                                && (!x.destinationCodes.Contains("BERMUDA"))
                                                && (!x.destinationCodes.Contains("CANADA_NEW_ENGL"))
                                                && (x.duration >= 7 && x.duration <= 14)
                                                && (x.portsOfCall.First() == "NYC" && x.portsOfCall.Last() == "NYC")
                                                ).ToList();

List<Itinerary> oceanViewList = new List<Itinerary>();
List<Itinerary> balconyList = new List<Itinerary>();

foreach( var nycVaction in nycvactions)
{
    foreach ( var sail in nycVaction.sailings)
    {
        foreach( var pricing in sail.pricing)
        {
            if(pricing.code == "OCEANVIEW" && pricing.status == "AVAILABLE")
            {
                Itinerary oceanViewItinerary = new Itinerary();
                oceanViewItinerary.Code = nycVaction.code;
                oceanViewItinerary.StateRoom = "OCEANVIEW";
                oceanViewItinerary.Duration = nycVaction.duration;
                oceanViewItinerary.DestinationCodes = string.Join("|", nycVaction.destinationCodes); 
                oceanViewItinerary.DepartureDate = DateTimeOffset.FromUnixTimeMilliseconds(sail.departureDate).DateTime;
                oceanViewItinerary.ReturndateTime = DateTimeOffset.FromUnixTimeMilliseconds(sail.returnDate).DateTime;
                oceanViewItinerary.CombinePrice = pricing.combinedPrice;
                oceanViewList.Add(oceanViewItinerary);
            }

            if (pricing.code == "BALCONY" && pricing.status == "AVAILABLE")
            {
                Itinerary balconyItinerary = new Itinerary();
                balconyItinerary.Code = nycVaction.code;
                balconyItinerary.StateRoom = "BALCONY";
                balconyItinerary.Duration = nycVaction.duration;
                balconyItinerary.DestinationCodes = string.Join("|", nycVaction.destinationCodes);
                balconyItinerary.DepartureDate = DateTimeOffset.FromUnixTimeMilliseconds(sail.departureDate).DateTime;
                balconyItinerary.ReturndateTime = DateTimeOffset.FromUnixTimeMilliseconds(sail.returnDate).DateTime;
                balconyItinerary.CombinePrice = pricing.combinedPrice;
                balconyList.Add(balconyItinerary);
            }
        }
    }
}

var ovFiltered = oceanViewList.Where(x => (x.ReturndateTime.Year == 2024)
                        && (x.DepartureDate.Year == 2024)).OrderBy(y=>y.PricePerday).FirstOrDefault();
var balconyItineraryFilter = balconyList.Where(x => (x.ReturndateTime.Year == 2024)
                        && (x.DepartureDate.Year == 2024)).OrderBy(y => y.PricePerday).FirstOrDefault();


Console.WriteLine($"The Lowest OceanView {ovFiltered}");
Console.WriteLine($"The Lowest balcony  {balconyItineraryFilter}");

Console.WriteLine("End");
