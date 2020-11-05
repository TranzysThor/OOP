using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            Debug.Indent();
            int zero = 0;
            Computer comp = new Computer();
            try
            {
                string param = Console.ReadLine();
                if (param.Length > 4)
                {
                    throw new Exception("Variable length is more than 4 characters");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                string param2 = Console.ReadLine();
                if (param2.Length == 0)
                {
                    throw new Exception("Empty value");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Software Word = new TextEditor("Word", 2019, "TextProcessor");
            Software Sublime = new TextEditor("Sublime", 3, "TextEditor");
            Software Rider = new TextEditor("Rider", 2020, "IDE");
            Software VSCode = new TextEditor("VSCode", 2020, "IDE");
            Software Dota2 = new Game("Dota2", 7, "MOBA");
            Software R6Siege = new Game("R6Siege", 1, "FPS");
            Software Valhalla = new Game("Valhalla", 1, "Adventure");
            Software CSGO  = new Game("CSGO", 1156, "FPS");
            comp.add(Word);
            comp.add(Sublime);
            comp.add(Rider);
            comp.add(VSCode);
            comp.add(Dota2);
            comp.add(R6Siege);
            comp.add(Valhalla);
            comp.add(CSGO);
            Debug.Assert(Valhalla.version != 0, "Valhalla.version != 0");
            Controller.GetSoftwareByVersion(comp, 2020);
            Controller.GetGameType(comp, "FPS");
            Controller.PrintSoftware(comp);
            Console.WriteLine("\nEnum.GetValues\n");
            foreach (var item in Enum.GetValues(typeof(Programs)))
            {
                Console.WriteLine(item);
            }
            try
            {
                int vers = Word.version;
                int result = vers / zero;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Console.WriteLine(comp.computer[8]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                object obj = "string";
                int num = (int) obj;
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Software prog = new TextEditor("Prog", 0, "Type");
                if (prog.version == 0)
                {
                    throw new Exception("Version can't be zero");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Software prog = new TextEditor("Prog", 1, "Type");
                Console.WriteLine("'Finally' block");
            }
            Debug.Unindent();
        }
    }

    static class Controller
    {
        public static void GetSoftwareByVersion(Computer comp, int version)
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
        public abstract int version { get; set; }
        public abstract string type { get; set; }
    }

    class TextEditor : Software
    {
        public override string name { get; set; }
        public override int version { get; set; }
        public override string type { get; set; }

        public TextEditor(string Name, int Version, string Type)
        {
            name = Name;
            version = Version;
            type = Type;
        }
    }

    class Game : Software
    {
        public override string name { get; set; }
        public override int version { get; set; }
        public override string type { get; set; }

        public Game(string Name, int Version, string Type)
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