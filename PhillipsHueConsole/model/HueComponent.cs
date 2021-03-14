using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhillipsHueConsole {
    public abstract class HueComponent {
        public abstract string Key { get; set; }
        public abstract string Name { get; set; }

        protected HueComponent(string name) => Name = name;

        public override string ToString() {
            return $"{Key}: {Name}";
        }
    }
}
