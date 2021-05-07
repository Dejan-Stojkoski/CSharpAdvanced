namespace Models
{
    public class Cat : Pet
    {
        public bool Lazy { get; set; }
        public int LivesLeft { get; set; }

        public Cat(string name, string type, int age, bool lazy, int livesLeft) : base(name,type,age)
        {
            Lazy = lazy;
            LivesLeft = livesLeft;
        }

        public override string GetInfo()
        {
            return $"{Name} is {Age} years old and has {LivesLeft} lives left.";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
