using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCLCapture
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Coordinates
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class Currency
    {
        public string code { get; set; }
        public string symbol { get; set; }
    }

    public class EmbarkationPort
    {
        public string code { get; set; }
        public Coordinates coordinates { get; set; }
    }

    public class Pricing
    {
        public string code { get; set; }
        public string status { get; set; }
        public int combinedPrice { get; set; }
        public List<string> offerCodes { get; set; }
    }

    public class Vacation
    {
        public string bundleType { get; set; }
        public string code { get; set; }
        public List<string> destinationCodes { get; set; }
        public EmbarkationPort embarkationPort { get; set; }
        public string shipCode { get; set; }
        public int duration { get; set; }
        public int guestCount { get; set; }
        public List<string> portsOfCall { get; set; }
        public List<object> excursionCodes { get; set; }
        public List<Sailing> sailings { get; set; }
        public Currency currency { get; set; }
        public int weight { get; set; }
    }

    public class Sailing
    {
        public string bundleType { get; set; }
        public int packageId { get; set; }
        public int sailId { get; set; }
        public long departureDate { get; set; }
        public long returnDate { get; set; }
        public List<Pricing> pricing { get; set; }
        public string itineraryCode { get; set; }
    }


}
