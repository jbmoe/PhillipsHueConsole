namespace PhillipsHueConsole.model {
    public abstract class HueComponent {
        public abstract string Key { get; set; }
        public abstract string Name { get; set; }

        protected HueComponent(string name) => Name = name;

        public override string ToString() {
            return $"{Key}: {Name}";
        }
    }
}
