using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhillipsHueConsole.model {
    class Sensor : HueComponent {
        public override string Key { get; set; }
        public override string Name { get; set; }

        [JsonConstructor]
        public Sensor(string name, string key) : base(name) {
            Key = key;
            Name = name;
        }
    }
}
