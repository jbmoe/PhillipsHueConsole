using Newtonsoft.Json;

namespace PhillipsHueConsole.model {
    class Schedule : HueComponent {
        public override string Key { get; set; }
        public override string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        [JsonConstructor]
        public Schedule(string name, string description, string status) : base(name) {
            Name = name;
            Description = description;
            Status = status;
        }
    }
}
