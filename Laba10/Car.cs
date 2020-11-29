using System;
using System.Collections.Generic;

namespace Laba10
{
    public class Car
    {
        private string _manufacturer;
        public string Manufacturer
        {
            get => _manufacturer;
            set => _manufacturer = value;
        }
        private IList<string> _models;
        public IList<string> Models
        {
            get => _models;
            set => _models = value;
        }
        public Car(string manufacturer, IList<string> models)
        {
            Manufacturer = manufacturer;
            Models = models;
        }
        public void Del(string model)
        {
            if (Models.Contains(model))
            {
                Models.Remove(model);
            }
        }
        public void Add(string model)
        {
            if (Models.Contains(model) == false)
            {
                Models.Add(model);
            }
            else
            {
                Console.WriteLine("Such model is already on the list");
            }
        }
        public void LookUp(string model)
        {
            if (Models.Contains(model))
            {
                Console.WriteLine($"{Manufacturer}'s model list contains {model}");
            }
            else
            {
                Console.WriteLine($"There is no such model as {model} in {Manufacturer}'s model list");
            }
        }
        public void Print()
        {
            Console.WriteLine($"{Manufacturer}'s model list consists of:");
            foreach (var model in Models)
            {
                Console.WriteLine(model);
            }
        }
    }
}