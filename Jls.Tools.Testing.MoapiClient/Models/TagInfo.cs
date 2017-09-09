using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jls.Tools.Testing.MoapiClient.Models
{
    public class TagInfo
    {
        private readonly CriteriaType ID;
        public CriteriaType Id => ID;

        public object Pointer { get; set; }

        public TagInfo(CriteriaType id, object pointer = null)
        {
            ID = id;
            Pointer = pointer;

        }
    }
}
