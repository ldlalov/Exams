
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals = new List<Animal>();
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; private set; }
        public IReadOnlyCollection<Animal> Animals => animals;

        public string AddAnimal(Animal animal)
        {

            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                sb.Append("Invalid animal species.");
            }
            else if (!(animal.Diet.ToLower() == "herbivore" || animal.Diet.ToLower() == "carnivore"))
            {
                sb.Append("Invalid animal diet.");
            }
            else if (animals.Count == Capacity)
            {
                sb.Append("The zoo is full.");
            }
            else
            {
                animals.Add(animal);
                sb.Append($"Successfully added {animal.Species} to the zoo.");

            }
            return sb.ToString().TrimEnd().TrimStart();
        }
        public int RemoveAnimals(string species)
        {
            int count = 0;
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Species == species)
                {
                    animals.Remove(animals[i]);
                    count++;
                    i--;
                }
            }
            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> specialAnimals = animals.FindAll(animal => animal.Diet == diet).ToList();
            return specialAnimals;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return animals.First(x => x.Weight == weight);
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = animals.Count(x => x.Length >= minimumLength && x.Length <= maximumLength);
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }

    }
}
