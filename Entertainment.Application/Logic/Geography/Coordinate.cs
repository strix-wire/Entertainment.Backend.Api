using Entertainment.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment.Application.Logic.Geography
{
    internal class Coordinate
    {
        private KeyValuePair<double, double> GetLatLonByArea(Area area)
        {
            return area switch
            {
                Area.Oktyabrsky => new KeyValuePair<double, double>(56.53235, 85.047632),
                Area.Leninsky => new KeyValuePair<double, double>(56.519052, 56.519052),
                Area.Kirovsky => new KeyValuePair<double, double>(56.455362, 84.951216),
                Area.Soviet => new KeyValuePair<double, double>(56.47906, 85.016239),
                _ => throw new NotImplementedException(),
            };
        }
        public double GetDistanceFromPlaceToArea(Area area, double lat, double lon)
        {
            KeyValuePair<double, double> latAndLong = GetLatLonByArea(area);

            return Math.Sqrt(Math.Pow(latAndLong.Key - lat, 2) + Math.Pow(latAndLong.Value - lon, 2));
        }
    }
}
