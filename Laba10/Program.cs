using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Microsoft.VisualBasic.CompilerServices;

namespace Laba10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> WagModels = new List<string>{"Polo", "Golf", "Golf R", "Passat", "Scirocco"};
            List<string> AudiModels = new List<string>{"TT", "R8", "Q8", "RS6", "A7"};
            List<string> FordModels = new List<string>{"Mustang", "Mondeo", "Focus", "Focus ST", "F150", "Fusion"};
            var Volkswagen = new Car("Volkswagen", WagModels);
            var Audi = new Car("Audi", AudiModels);
            var Ford = new Car("Ford", FordModels);
            var Cars = new ObservableCollection<Car>();
            Cars.CollectionChanged += Notify;
            Cars.Add(Volkswagen);
            Cars.Add(Audi);
            Cars.Add(Ford);
            Cars[0].Add("Touareg");
            Cars[1].LookUp("R8");
            Cars[2].Del("F150");
            Cars[2].LookUp("TT");
            Cars[0].Print();
            Cars[2].Print();
            Cars.Remove(Ford);
            Console.WriteLine("\n-----------------------------------------------------------------\n");
            Dictionary<object, object> randomDictionary = new Dictionary<object, object>();
            randomDictionary.Add("Minsk", 2_000_000);
            randomDictionary.Add("Maxim", 'M');
            randomDictionary.Add(2000, "TMMLP");
            foreach (var keyValue in randomDictionary)
            {
                Console.WriteLine($"{keyValue.Key} is a key to {keyValue.Value}");
            }
            randomDictionary.TryAdd(2020, true);
            randomDictionary.Remove("Minsk");
            randomDictionary.TryAdd(Audi, AudiModels);
            Console.WriteLine("\n-----------------------------------------------------------------\n");
            SortedList<object, object> randSortedList = new SortedList<object, object>();
            foreach (var keyValue in randomDictionary)
            {
                randSortedList.Add(keyValue.Key.ToString(), keyValue.Value.ToString());
            }
            foreach (var keyValue in randSortedList)
            {
                Console.WriteLine($"{keyValue.Key} is a key to {keyValue.Value}");
            }
            Console.WriteLine(randSortedList.ContainsValue("TMMLP"));
            
        }
        private static void Notify(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                {
                    Car newCar = e.NewItems[0] as Car;
                    Console.WriteLine($"Added New Manufacturer {newCar.Manufacturer}");
                    break;
                }
                case NotifyCollectionChangedAction.Remove:
                {
                    Car oldCar = e.OldItems[0] as Car;
                    Console.WriteLine($"Removed Manufacturer {oldCar.Manufacturer}");
                    break;
                }
            }
        }
    }
}