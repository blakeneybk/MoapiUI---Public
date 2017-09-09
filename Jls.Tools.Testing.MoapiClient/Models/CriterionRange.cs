using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    public class CriterionRange<T> where T : struct
    {
        private T _max;
        private bool _set;

        public T Min { get; set; }

        public T Max
        {
            get { return _max; }
            set
            {
                _max = value;
                _set = true;
            }
        }

        public override string ToString()
        {
            return $"R:{Min},{(_set ? _max.ToString() : "?")}";
        }
    }
}
