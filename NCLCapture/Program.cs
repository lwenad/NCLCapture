using

    // See https://aka.ms/new-console-template for more information


   string request =  "https://www.ncl.com/api/vacations/v2/itineraries?guests=2";
    https://www.ncl.com/api/vacations/v2/search-result-itinerary/GETAWAY5NYCWRFNYC?guests=2&v=332056977-1694115153843

HttpClient client = new HttpClient();
    string  request = "https://www.ncl.com/vacations?cruise-port=nyc&duration=5-8&sort=price_low_high";
var response = await client.GetAsync(request);

    if(response.IsSuccessStatusCode)
{
    var result = await response.Content.ReadAsStringAsync();
}

Console.WriteLine("Hello, World!");
