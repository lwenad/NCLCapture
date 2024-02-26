using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NCLCapture
{
    public class NclApiClient
    {

        public async Task<List<Vacation>> GetVcationItineraries()
        {
            List<Vacation> result = null;
            string request = "https://www.ncl.com/api/vacations/v2/itineraries?guests=2";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Vacation>>(responseString);

            }

            return result;

        }

        public async Task<string>  Getitinerary(string code)
        {
            string result = null;

            string request = " https://www.ncl.com/api/vacations/v2/search-result-itinerary/GETAWAY5NYCWRFNYC?guests=2&v=332056977-1694115153843";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
               result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }

    // get fee    "https://www.ncl.com/booking/api/vacation-availability"

    }
}
