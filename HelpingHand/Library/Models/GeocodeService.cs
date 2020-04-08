using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace HelpingHand.Library.Models
{
    public class GeocodeService
    {
        public GeocodeService()
        {

        }

        //public async Task<Address> GetCoords()
        //{
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.GetAsync($"maps.googleapis.com/maps/api/geocode/json?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&key={API_Keys.GoogleAPIKey}");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string json = response.Content.ReadAsStringAsync().Result;
        //        return JsonConvert.DeserializeObject<Address>(json);
        //    }
        //    return null;


        //}

    }
}
