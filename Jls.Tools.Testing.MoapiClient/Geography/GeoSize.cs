using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jls.Tools.Testing.MoapiClient.Geography
{
    public struct GeoSize
    {
        public static GeoSize Empty = new GeoSize(0, 0);
        private float _height;
        private float _width;

        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public GeoSize(float width, float height)
        {
            _width = width;
            _height = height;
        }

        public override string ToString()
        {
            return String.Format("GeoSize {{ Width:{0}, Height:{1} }}", _width, _height);
        }

        public static bool operator !=(GeoSize s1, GeoSize s2)
        {
            return !(s1 == s2);
        }

        public static bool operator ==(GeoSize s1, GeoSize s2)
        {
            return (s1.Width == s2.Width && s1.Height == s2.Height);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

    }
}
