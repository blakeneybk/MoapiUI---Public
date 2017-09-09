using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jls.Tools.Testing.MoapiClient.Geography
{
    public struct GeoRectangle
    {
        private GeoPoint _location;
        private GeoPoint _locationEnd;
        private GeoSize _size;

        // public GeoRectangle() { }

        public GeoRectangle(GeoPoint locationStart, GeoPoint locationEnd)
        {
            _location = locationStart;
            _locationEnd = locationEnd;
            _size = locationEnd - _location;
        }

        public GeoRectangle(float startLat, float startLon, float endLat, float endLon)
        {
            _location = new GeoPoint(startLat, startLon);
            _locationEnd = new GeoPoint(endLat, endLon);
            _size = _locationEnd - _location;
        }

        public GeoPoint Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public GeoPoint LocationEnd
        {
            get { return _locationEnd; }
            set { _locationEnd = value; }
        }

        public GeoSize Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public static GeoRectangle Parse(string areaString)
        {
            string[] points = areaString.Split(',');
            if (points.Length < 2)
                throw new FormatException("Invalid area string.  Not enough points to generate a GeoRectangle.");

            string[] location = points[0].Split(' ');
            string[] locationEnd = points[1].Split(' ');

            GeoRectangle geoRect = new GeoRectangle(
                float.Parse(location[1]),
                float.Parse(location[0]),
                float.Parse(locationEnd[1]),
                float.Parse(locationEnd[0]));

            return geoRect;
        }

        public GeoPoint Middle()
        {
            return new GeoPoint(Location.Latitude - LocationEnd.Latitude, Location.Longitude - LocationEnd.Longitude);
        }

        public void Inflate(float x, float y)
        {

        }

        public bool Contains(GeoPoint p)
        {
            if ((p.Latitude >= _location.Latitude && p.Latitude <= (_location.Latitude + _size.Height)) &&
                (p.Longitude >= _location.Longitude && p.Longitude <= (_location.Longitude + _size.Width)))
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return String.Format("GeoRectangle {{ Location:{0}, Size:{1} }}", Location, Size);
        }

        public string ToString(bool searchFormat)
        {
            //return $"{Location.Latitude} {Location.Longitude},{LocationEnd.Latitude} {LocationEnd.Longitude}";            
            return $"{LocationEnd.Latitude} {Location.Longitude},{Location.Latitude} {LocationEnd.Longitude}";
        }
    }
}
