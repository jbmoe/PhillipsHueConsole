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
        private LightState action;

        public override string Key { get; set; }
        public override string Name { get; set; }
        [JsonProperty("lights")]
        public int[] LightKeys;
        public List<Light> Lights { get; set; }
        public string Type { get; set; }
        public LightState State {
            get { return action; }
            set {
                action = value;
                action.Component = this;
            }
        }
        public string Class { get; set; }

        public override string ToString() {
            string toReturn = base.ToString() + $" - {Lights.Count} lights";
            //Lights.ForEach(e => toReturn += e.ToString() + "\n");
            return toReturn.TrimEnd();
        }

        //public GroupState State { get; set; }
        //public class GroupState {
        //    public string All_on { get; set; }
        //    public string Any_on { get; set; }

        //    public override string ToString() {
        //        return $"All_on: {All_on}\nAny_on: {Any_on}";
        //    }
        //}
    }
}
