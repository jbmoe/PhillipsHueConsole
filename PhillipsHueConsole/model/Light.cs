using Newtonsoft.Json;
using PhillipsHueConsole;
using System;

namespace test.model {
    public class Light : HueComponent {
        public override int ComponentKey { get; set; }
        public string Name { get; set; }
        public LightState State { get; set; }


        public override string ToString() {
            return $"{ComponentKey}: {Name} - {(State.On ? "ON" : "Off")}";
        }

        public struct LightState {
            public bool On { get; set; }

            [JsonProperty("bri")]
            public int Brightness { get; set; }

            public int Hue { get; set; }

            [JsonProperty("sat")]
            public int Saturation { get; set; }

            public string Effect { get; set; }

            public double[] XY { get; set; }

            public override string ToString() {
                return $"On: {On}\nBri: {Brightness}\nHue: {Hue}\nSat: {Saturation}\nEffect: {Effect}\nXY: [{XY[0]}, {XY[1]}]";
            }
        }
    }
}
