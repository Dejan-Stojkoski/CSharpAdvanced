using System;
using System.Collections.Generic;
using Models;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Dog> dogs = new List<Dog>
            {
                new Dog(4, "Sparky", "Brown"),
                new Dog(-1, "Marky", "Yellow"),
                new Dog(1, "A", "Yellow"),
                new Dog()
            };

            foreach(Dog dog in dogs)
            {
                if (Dog.Validate(dog))
                {
                    DogShelter.Dogs.Add(dog);
                }
            }

            Console.WriteLine(DogShelter.GetAllDogsNames());
        }
    }
}
