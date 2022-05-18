using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IOModels
{
    public class AirportResponseModel
    {
        public string Country { get; set; }
        public string City_iata { get; set; }
        public string Iata { get; set; }
        public string City { get; set; }
        public string Timezone_region_name { get; set; }
        public string Country_iata { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public string Type { get; set; }
        public bool Hubs { get; set; }
    }

    public class Location
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
    
}
