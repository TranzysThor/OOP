using System;
using System.Collections.Generic;

namespace Laba6
{
    enum Programs
    {
        Word,
        Sublime = 2,
        Rider = 4,
        VSCode,
        Dota2,
        R6Siege,
        Valhalla,
        CSGO
    }
    class Program
    {
        static void Main(string[] args)
        {
            Computer comp = new Computer();
            Software Word  = new TextEditor("Word", "2019", "TextProcessor");
            Software Sublime = new TextEditor("Sublime", "3", "TextEditor");
            Software Rider = new TextEditor("Rider", "2020", "IDE");
            Software VSCode = new TextEditor("VSCode", "2020", "IDE");
            Software Dota2 = new Game("Dota2", "7.29", "MOBA");
            Software R6Siege = new Game("R6Siege", "1.90", "FPS");
            Software Valhalla = new Game("Valhalla", "1", "Adventure");
            Software CSGO  = new Game("CSGO", "1156", "FPS");
            comp.add(Word);
            comp.add(Sublime);
            comp.add(Rider);
            comp.add(VSCode);
            comp.add(Dota2);
            comp.add(R6Siege);
            comp.add(Valhalla);
            comp.add(CSGO);
            Controller.GetSoftwareByVersion(comp, "2020");
            Controller.GetGameType(comp, "FPS");
            Controller.PrintSoftware(comp);
            Console.WriteLine("\nEnum.GetValues\n");
            foreach (var item in Enum.GetValues(typeof(Programs)))
            {
                Console.WriteLine(item);
            }
        }
    }

    static class Controller
    {
        public static void GetSoftwareByVersion(Computer comp, string version)
        {
            foreach (var soft in comp.computer)
            {
                if (version == soft.version)
                {
                    Console.WriteLine($"{soft.name} - software with the version {version}");
                }
            }
        }

        public static void PrintSoftware(Computer comp)
        {
            foreach (var soft in comp.computer)
            {
                Console.WriteLine(soft.name);
            }
        }

        public static void GetGameType(Computer comp, string type)
        {
            foreach (var soft in comp.computer)
            {
                if (type == soft.type)
                {
                    Console.WriteLine($"{type} game: {soft.name}");
                }
            }
        }
    }

    public class Computer
    {
        public List<Software> computer = new List<Software> { };

        public void add(Software name)
        {
            computer.Add(name);
        }

        public void Del(Software name)
        {
            foreach (var item in computer)
            {
                int pos = 0;
                if (item == name)
                {
                    computer.RemoveAt(pos);
                    break;
                }
                pos++;
            }
        }

        public void print()
        {
            foreach (var item in computer)
            {
                Console.WriteLine(item.name);
            }
        }
    }

    public abstract partial class Software : Computer
    {
        public abstract string name { get; set; }
        public abstract string version { get; set; }
        public abstract string type { get; set; }
    }

    class TextEditor : Software
    {
        public override string name { get; set; }
        public override string version { get; set; }
        public override string type { get; set; }

        public TextEditor(string Name, string Version, string Type)
        {
            name = Name;
            version = Version;
            type = Type;
        }
    }

    class Game : Software
    {
        public override string name { get; set; }
        public override string version { get; set; }
        public override string type { get; set; }

        public Game(string Name, string Version, string Type)
        {
            name = Name;
            version = Version;
            type = Type;
        }

        struct Programma
        {
            public int year;
            public string developer;
        }
    }
}