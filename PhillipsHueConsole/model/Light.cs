using Newtonsoft.Json;
using PhillipsHueConsole;
using System;

namespace test.model {
    public class Light : HueComponent {
        #region properties
        public override int ComponentKey { get; set; }
        public LightState State { get; set; }
        public string Name { get; set; }
        public string ProductName { get; set; }
        [JsonProperty("uniqueid")]
        public string UniqueID { get; set; }
        #endregion
        public override string ToString() {
            return $"{ComponentKey}: {Name} - {(State.On ? "ON" : "Off")}";
        }
        #region inner class for encapsulating
        public class LightState {

            #region fields
            [JsonProperty("on")]
            private bool on;
            [JsonProperty("bri")]
            private int bri;
            [JsonProperty("hue")]
            private int hue;
            [JsonProperty("sat")]
            private int sat;
            [JsonProperty("effect")]
            private string effect;
            [JsonProperty("xy")]
            private double[] xy;
            #endregion

            #region properties
            public bool On {
                get { return on; }
                set { on = value; }
            }
            /// <summary>
            /// Brightness value of light. Values goes from 1-2k54, if exceeded an error is thrown
            /// </summary>
            public int Brightness {
                get { return bri; }
                set {
                    if (value < 1 || value > 255) throw new ArgumentException(string.Format($"Value: {0} must be less than 255 and greater or equal to 0", nameof(value)));
                    bri = value;
                }
            }
            public int Hue {
                get { return hue; }
                set { hue = value; }
            }
            public int Saturation {
                get { return sat; }
                set { sat = value; }
            }
            public string Effect {
                get { return effect; }
                set { effect = value; }
            }
            public double[] XY {
                get { return xy; }
                set { xy = value; }
            }
            #endregion

            public override string ToString() {
                return String.Format("On: {0}\nBri: {1}\nHue: {2}\nSat: {3}\nEffect: {4}\nXY: [{5}, {6}]"
                    , On, Brightness, Hue, Saturation, Effect, XY[0], XY[1]); ;
            }
        }
        #endregion
    }
}
