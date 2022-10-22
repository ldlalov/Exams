using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> drones = new List<Drone>();

        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }

        public IReadOnlyCollection<Drone> Drones => drones;
        public int Count => drones.Count;
        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name) || string.IsNullOrEmpty(drone.Brand) || drone.Range < 5 || drone.Range > 15)
            {
                return $"Invalid drone.";
            }
            if (Count == Capacity)
            {
                return $"Airfield is full.";
            }
            drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";

        }
        public bool RemoveDrone(string name)
        {
            if (drones.FirstOrDefault(x => x.Name == name) != null)
            {
                    drones.Remove(drones.FirstOrDefault(x => x.Name == name));
                return true;
            }
            return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            int count = drones.Count;
            drones.RemoveAll(x => x.Brand == brand);
            return count -= drones.Count;
        }
        public Drone FlyDrone(string name)
        {

            foreach (var drone in drones)
            {
                if (drone.Name == name)
                {
                    drone.Available = false;
                    return drone;
                }
            }
            return null;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            foreach (var drone in drones)
            {
                if (drone.Range>= range)
                {
                    drone.Available = false;
                }
            }
            return drones.Where(x => x.Range >= range).ToList();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            foreach (var fish in drones.Where(d => d.Available == true))
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }



        private bool fly(string name)
        {
            foreach (var drone in drones)
            {
                if (drone.Name == name)
                {
                    drone.Available = false;
                    return true;
                }
            }
            return false;
        }

    }
}
