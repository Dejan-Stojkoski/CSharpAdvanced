using System.Collections.Generic;
using System.Linq;

namespace Models.Database
{
    public class GenericDb<T> where T : Pet
    {
        private List<T> List;

        public GenericDb()
        {
            List = new List<T>();
        }

        public string GetPets()
        {
            if(List.Count == 0)
            {
                return $"You doesn't have any pets yet!";
            }

            return string.Join(", ", List);
        }

        public void AddPet(T pet)
        {
            List.Add(pet);
        }

        public T BuyPet(string name)
        {
            T pet = List.FirstOrDefault(x => x.Name == name);

            if(pet != null)
            {
                List.Remove(pet);
            }

            return pet;
        }
    }
}
