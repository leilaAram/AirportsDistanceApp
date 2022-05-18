using Core.Autofac;
using Core.IOModels;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ICalculatingDistanceService : ISingletonDependency
    {
        Task<JsonResponse> CalculateAirportsDistanceAsync( string source, string destination );
    }
    public class CalculatingDistanceService : ICalculatingDistanceService
    {
        private IOptions<Settings> _settings;

        public CalculatingDistanceService( IOptions<Settings> settings )
        {
            _settings = settings;
        }
        public async Task<JsonResponse> CalculateAirportsDistanceAsync( string source, string destination )
        {
            var from = await GetAirport( source );
            var to = await GetAirport( destination );
            
            var fromCoord = new GeoCoordinatePortable.GeoCoordinate( from.Location.lat, from.Location.lon );
            var toCoord = new GeoCoordinatePortable.GeoCoordinate( to.Location.lat , to.Location.lon );

            var result = fromCoord.GetDistanceTo( toCoord ) / 0.000621371;
            return new JsonResponse()
            {
                Data = result,
                IsSuccess = true
            };
        }

        private async Task<AirportResponseModel> GetAirport( string code )
        {
            var apiUrl = $"{_settings.Value.AirportInfoAPI}{code.ToUpper()}";
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri( apiUrl ),
            };
            string body = "";
            var response = await client.SendAsync( request );
            response.EnsureSuccessStatusCode();
            body = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<AirportResponseModel>( body );

            return result;
        }
    }
}
