using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }


        public List<Renovator> renovators = new List<Renovator>();
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => renovators.Count;

        public string AddRenovator(Renovator renovator)
        {

            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                sb.Append("Invalid renovator's information.");
            }
            else if (NeededRenovators == Count)
            {
                sb.Append("Renovators are no more needed.");
            }
            else if (renovator.Rate>350)
            {
                sb.Append("Invalid renovator's rate.");
            }
            else
            {
                renovators.Add(renovator);
                sb.Append($"Successfully added {renovator.Name} to the catalog.");
                //Count++;
            }
            return sb.ToString();
        }
        public bool RemoveRenovator(string name)
        {
            for (int i = 0; i < renovators.Count; i++)
            {
                if (renovators[i].Name == name)
                {
                    renovators.Remove(renovators[i]);
                    return true;
                }
            }
            return false;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = renovators.Count;
            renovators.RemoveAll(x => x.Type == type);
            return count - renovators.Count;
        }
        public Renovator HireRenovator(string name)
        {
            foreach (var renovator in renovators)
            {
                if (renovator.Name == name)
                {
                    renovator.Hired = true;
                    return renovator;
                }
            }
            return null;
        }
        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> paydRenovators = new List<Renovator>(renovators.Where(x=> x.Days>=days));
            return paydRenovators;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var renovator in renovators.Where(x=> x.Hired == false))
            {
                sb.AppendLine(renovator.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
