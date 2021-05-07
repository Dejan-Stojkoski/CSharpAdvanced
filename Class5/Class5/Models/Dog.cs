namespace Models
{
    public class Dog : Pet
    {
        public bool GoodBoi { get; set; }
        public string FavouriteFood { get; set; }
        public Dog(string name, string type, int age, bool goodBoi, string favouriteFood) : base(name,type,age)
        {
            GoodBoi = goodBoi;
            FavouriteFood = favouriteFood;
        }

        public override string GetInfo()
        {
            return $"{Name}'s favourite food is {FavouriteFood}.";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
