using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhillipsHueConsole {
    public abstract class HueComponent {
        public abstract int ComponentKey { get; set; }
    }
}
