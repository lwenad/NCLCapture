using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCLCapture
{
    public class NclApiClient
    {
        
         public async Task<string> GetVcationItineraries()
        {

            string request = "https://www.ncl.com/api/vacations/v2/itineraries?guests=2";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
            }

            return "yes";

        }

        public async Task<string>  Getitinerary(string code)
        {
            string request = " https://www.ncl.com/api/vacations/v2/search-result-itinerary/GETAWAY5NYCWRFNYC?guests=2&v=332056977-1694115153843";

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
            }

            return "yes";
        }


    }
}
