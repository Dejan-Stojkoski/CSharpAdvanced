namespace Models
{
    public class Fish : Pet
    {
        public string Color { get; set; }
        private double _size { get; set; }
        public string Size => $"{_size} cm";
        public Fish(string name, string type, int age, string color, double size) : base(name,type,age)
        {
            Color = color;
            _size = size;
        }

        public override string GetInfo()
        {
            return $"The fish {Name} is {Size} long.";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
