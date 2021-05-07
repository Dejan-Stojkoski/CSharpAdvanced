using System;
using Models;
using Models.Database;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericDb<Dog> DogStore = new GenericDb<Dog>();
            GenericDb<Cat> CatStore = new GenericDb<Cat>();
            GenericDb<Fish> FishStore = new GenericDb<Fish>();

            DogStore.AddPet(new Dog("Scout", "French Bulldog", 3, true, "Chicken"));
            DogStore.AddPet(new Dog("Tucker", "Golden Retriever", 2, true, "Chicken"));

            CatStore.AddPet(new Cat("Garfild", "Persian", 1, true, 3));
            CatStore.AddPet(new Cat("Tom", "Russian Blue", 5, false, 9));

            FishStore.AddPet(new Fish("Goldie", "Golden Fish", 4, "Gold", 5.3));
            FishStore.AddPet(new Fish("Nemo", "Clown Fish", 1, "Red/Black/White", 7.3));

            Console.WriteLine("Dogs: " + DogStore.GetPets());
            Console.WriteLine("Cats: " + CatStore.GetPets());
            Console.WriteLine("Fishes: " + FishStore.GetPets());

            DogStore.BuyPet("Scout");
            CatStore.BuyPet("Tom");

            Console.WriteLine("Dogs: " + DogStore.GetPets());
            Console.WriteLine("Cats: " + CatStore.GetPets());
            Console.WriteLine("Fishes: " + FishStore.GetPets());
        }
    }
}
