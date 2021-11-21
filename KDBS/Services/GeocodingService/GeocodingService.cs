using System.Net.Http;
using System.Threading.Tasks;
using KDBS.Models;
using KDBS.Models.Exceptions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace KDBS.Services.GeocodingService
{
    internal class GeocodingService : IGeocodingService
    {
        private readonly IConfiguration _configuration;

        public GeocodingService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Coordinate> GetCoordinate(string address, int zipcode)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(CreateBingMapsCall(zipcode.ToString(), address));

            var apiResponse = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(apiResponse);

            if (json["statusCode"].ToString() != "200")
            {
                throw new CoordinateNotFoundException("Bing maps returned without success");
            }

            var latitude = double.Parse(json["resourceSets"][0]["resources"][0]["point"]["coordinates"][0].ToString());
            var longitude = double.Parse(json["resourceSets"][0]["resources"][0]["point"]["coordinates"][1].ToString());

            var coordinate = new Coordinate(latitude, longitude);
            return coordinate;
        }

        private string CreateBingMapsCall(string postalCode, string address)
        {
            var key = _configuration.GetValue<string>("BingMaps");
            return $@"https://dev.virtualearth.net/REST/v1/Locations?countryRegion=dk&postalCode={postalCode}&addressLine={address}&key={key}";
        }
    }
}
