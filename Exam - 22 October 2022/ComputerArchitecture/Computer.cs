using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace ComputerArchitecture
{
    public class Computer
    {
        private List<CPU> multiprocessor = new List<CPU>();
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public IReadOnlyCollection<CPU> Multiprocessor => multiprocessor;
        public int Count => Multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (Count< Capacity)
            {
                multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand)
        {
            if (multiprocessor.FirstOrDefault(x => x.Brand == brand) != null)
            {
                multiprocessor.RemoveAll(x => x.Brand == brand);
                return true;
            }
            return false;
        }
        public CPU MostPowerful()
        {
            return Multiprocessor.OrderByDescending(x => x.Frequency).FirstOrDefault();
        }
        public CPU GetCPU(string brand)
        {
            return multiprocessor.FirstOrDefault(x => x.Brand == brand);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var cpu in multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
