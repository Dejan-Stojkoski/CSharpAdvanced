using System;
using System.Collections.Generic;

namespace Models
{
    public static class DogShelter
    {
        public static List<Dog> Dogs { get; set; }

        static DogShelter()
        {
            Dogs = new List<Dog>
            {
                new Dog(1, "Tucker", "Gold"),
                new Dog(2, "Scout", "Blue"),
                new Dog(3, "Bark", "Black")
            };
        }

        public static string GetAllDogsNames()
        {
            if(Dogs.Count == 0)
            {
                return $"There are no dogs available at the moment!";
            }

            string dogNames = "";
            int counter = 1;

            foreach(Dog dog in Dogs)
            {
                dogNames += $"{counter}. {dog.Name}\n";
                counter++;
            }

            return dogNames;
        }
    }
}
