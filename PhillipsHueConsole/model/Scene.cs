using Newtonsoft.Json;
using System.Collections.Generic;

namespace PhillipsHueConsole.model {
    class Scene : HueComponent, IHasLights {
        public override string Key { get; set; }
        public override string Name { get; set; }
        public int groupKey;
        public Group Group { get; set; }
        public string[] lightKeys { get; set; }
        public List<Light> Lights { get; set; }
        public string Owner { get; set; }

        [JsonConstructor]
        public Scene(string name, int group, string[] lights, string owner) : base(name) {
            groupKey = group;
            lightKeys = lights;
            Owner = owner;
        }
    }
}
