using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jls.Tools.Testing.MoapiClient.Geography
{
    public struct GeoPoint
    {
        private float _latitude; //= -1;
        private float _longitude;// = -1;
        private const double EARTH_RADIUS_IN_MILES = 3956.0;
        private const double EARTH_RADIUS_IN_KILOMETERS = 6367.0;

        public static readonly GeoPoint Null = new GeoPoint();

        //public GeoPoint() {}

        public GeoPoint(float latitude, float longitude)
        {
            this._latitude = latitude;
            this._longitude = longitude;
        }

        /// <summary>
        /// Gets or sets the latitude coord
        /// </summary>
        public float Latitude
        {
            get { return _latitude; }
            set { _latitude = value; }
        }

        /// <summary>
        /// Gets or sets the longitude coord
        /// </summary>
        public float Longitude
        {
            get { return _longitude; }
            set { _longitude = value; }
        }

        /// <summary>
        /// Evaluates the distance between two points on Earth using the Haversine Formula 
        /// (http://en.wikipedia.org/wiki/Haversine_formula)
        /// </summary>
        /// <param name="point">Point to evaluate</param>
        /// <returns>Distance in miles or km</returns>
        public double Distance(GeoPoint point, bool useMetric = false)
        {
            return ((useMetric ? EARTH_RADIUS_IN_KILOMETERS : EARTH_RADIUS_IN_MILES) * 2 *
                (
                    Math.Asin(
                        Math.Min(1,
                            Math.Sqrt(
                                (
                                    Math.Pow(Math.Sin((DiffRadian(this.Latitude, point.Latitude)) / 2.0), 2.0) +
                                    Math.Cos(ToRadian(this.Latitude)) * Math.Cos(ToRadian(point.Latitude)) *
                                    Math.Pow(Math.Sin((DiffRadian(this.Longitude, point.Longitude)) / 2.0), 2.0)
                                )
                            )
                        )
                    )
                )
            );
        }

        private double ToRadian(double val)
        {
            return val * (Math.PI / 180);
        }

        private double DiffRadian(double a, double b)
        {
            return ToRadian(b) - ToRadian(a);
        }

        public override string ToString()
        {
            return String.Format("GeoPoint {{ Lat:{0}, Long:{1} }}", _latitude, _longitude);
        }

        #region Operator Overrides
        public static GeoSize operator -(GeoPoint a, GeoPoint b)
        {
            return (new GeoSize(a.Longitude - b.Longitude, a.Latitude - b.Latitude));
        }

        public static bool operator ==(GeoPoint a, GeoPoint b)
        {
            return (a.Latitude == b.Latitude && a.Longitude == b.Longitude);
        }

        public static bool operator !=(GeoPoint a, GeoPoint b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        #endregion
    }
}
