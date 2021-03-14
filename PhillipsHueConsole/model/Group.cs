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
            string toReturn = $"{ComponentKey}: {Name} - {Lights.Count} lights";
            //Lights.ForEach(e => toReturn += e.ToString() + "\n");
            return toReturn.TrimEnd();
        }

        public class GroupState {
            public string All_on { get; set; }
            public string Any_on { get; set; }

            public override string ToString() {
                return $"All_on: {All_on}\nAny_on: {Any_on}";
            }
        }
        public class GroupAction {
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
