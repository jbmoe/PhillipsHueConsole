using Newtonsoft.Json;
using PhillipsHueConsole;
using PhillipsHueConsole.model;
using System;

namespace test.model {
    public class Light : HueComponent {
        private LightState state;
        public override string Key { get; set; }
        public override string Name { get; set; }
        public LightState State {
            get { return state; }
            set {
                state = value;
                state.Component = this;
            }
        }

        public override string ToString() {
            return base.ToString() + $" - { (State.On ? "ON" : "Off")}";
        }
    }
}
