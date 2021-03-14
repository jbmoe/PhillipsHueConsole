using Newtonsoft.Json;

namespace PhillipsHueConsole.model {
    public class Light : HueComponent {
        public override string Key { get; set; }
        public override string Name { get; set; }
        private LightState state;
        public LightState State { get { return state; } }

        [JsonConstructor]
        public Light(string name, bool on, int bri, int hue, int sat, string effect, double[] xy) : base(name) {
            LightState state = InitState(on, bri, hue, sat, effect, xy);
            this.state = state;
        }

        private LightState InitState(bool on, int bri, int hue, int sat, string effect, double[] xy) {
            LightState state = new(on, bri, hue, sat, effect, xy);
            state.Component = this;
            return state;
        }

        public override string ToString() {
            return base.ToString() + $" - { (State.On ? "ON" : "Off")}";
        }
    }
}
