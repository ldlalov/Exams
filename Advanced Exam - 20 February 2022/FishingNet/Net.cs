using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fishes = new List<Fish>();
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
        }
        public int Count => fishes.Count;
        public IReadOnlyCollection<Fish> Fish => fishes;
        public string Material { get; set; }
        public int Capacity { get; set; }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Weight<=0 || fish.Length<=0)
            {
                return $"Invalid fish.";
            }
            if (Count== Capacity)
            {
                return $"Fishing net is full.";
            }
            fishes.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            if (fishes.FirstOrDefault(x => x.Weight == weight) != null)
            {
                fishes.Remove(fishes.FirstOrDefault(x => x.Weight == weight));
                return true;
            }
            return false;
        }
        public Fish GetFish(string fishType)
        {
            return fishes.FirstOrDefault(x => x.FishType == fishType);
        }
        public Fish GetBiggestFish()
        {
            return fishes.OrderByDescending(x => x.Weight).First();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var fish in fishes.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
