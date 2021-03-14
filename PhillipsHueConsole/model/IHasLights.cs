using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhillipsHueConsole.model {
    interface IHasLights {
        public string[] lightKeys { get; set; }
        public List<Light> Lights { get; set; }
    }
}
