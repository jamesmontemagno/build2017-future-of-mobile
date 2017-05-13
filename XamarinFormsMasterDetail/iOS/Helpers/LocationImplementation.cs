using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CoreLocation;

namespace Forms.iOS.Helpers
{
    
    public static class LocationImplementation
    {
        public static void GetLocation(Action<double, double> gotLocation)
        {
            var locator = new CLLocationManager();
            locator.RequestWhenInUseAuthorization();
            locator.LocationsUpdated += (object sender, CLLocationsUpdatedEventArgs e) =>
            {
                var l = e.Locations[0].Coordinate;
                gotLocation?.Invoke(l.Latitude, l.Longitude);
            };

            locator.StartUpdatingLocation();
        }
        
    }
}