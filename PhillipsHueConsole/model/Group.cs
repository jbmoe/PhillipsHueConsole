using Newtonsoft.Json;
using PhillipsHueConsole;
using PhillipsHueConsole.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.model {
    class Group : HueComponent {
        public override string Key { get; set; }
        public override string Name { get; set; }
        public int[] LightKeys;
        public List<Light> Lights { get; set; }
        public string Type { get; set; }
        private LightState action;
        public LightState Action { get { return action; } }
        public string Class { get; set; }

        [JsonConstructor]
        public Group(string name, int[] lights, string type, string Class, bool on, int bri, int hue, int sat, string effect, double[] xy) : base(name) {
            LightState action = InitAction(on, bri, hue, sat, effect, xy);
            this.action = action;
            LightKeys = lights;
            Type = type;
            this.Class = Class;
        }

        private LightState InitAction(bool on, int bri, int hue, int sat, string effect, double[] xy) {
            LightState state = new(on, bri, hue, sat, effect, xy);
            state.Component = this;
            return state;
        }

        public override string ToString() {
            string toReturn = base.ToString() + $" - {Lights.Count} lights";
            //Lights.ForEach(e => toReturn += e.ToString() + "\n");
            return toReturn.TrimEnd();
        }
    }
}
