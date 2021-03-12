using Newtonsoft.Json;
using PhillipsHueConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.model {
    class Group : HueComponent {
        #region properties
        public override int ComponentKey { get; set; }
        public string Name { get; set; }
        [JsonProperty("lights")]
        public int[] LightKeys { get; set; }
        public List<Light> Lights { get; set; }
        public string Type { get; set; }
        public GroupState State { get; set; }
        public GroupAction Action { get; set; }
        public string Class { get; set; }
        #endregion
        public override string ToString() {
            string toReturn = $"{ComponentKey}: {Name}\n";
            Lights.ForEach(e => toReturn += e.ToString() + "\n");
            return toReturn.TrimEnd();
        }
        #region inner classes for encapsulating
        public class GroupState {
            #region fields
            [JsonProperty("all_on")]
            private string all_on;
            [JsonProperty("any_on")]
            private string any_on;
            #endregion
            #region properties
            public string All_on {
                get { return all_on; }
                set { all_on = value; }
            }
            public string Any_on {
                get { return any_on; }
                set { any_on = value; }
            }
            #endregion
            public override string ToString() {
                return string.Format("All_on: {0}\nAny_on: {1}", all_on, any_on);
            }
        }
        public class GroupAction {
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
