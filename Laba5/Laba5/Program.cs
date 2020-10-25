using System;
using System.Collections.Generic;

namespace Laba5
{
    class Program
    {
        static void Main(string[] args)
        {
            CConfickerGame sapper = new Sapper(1997, "Puzzle", "Microsoft");
            CConfickerGame worm = new Virus(1988, "worm", "Ray Tomlinson");
            ITextEditor word = new Software();
            sapper.Display();
            worm.Display();
            Console.WriteLine(worm is Virus);
            Console.WriteLine(worm is CConfickerGame);
            IOperationList op = word as IOperationList;
            CConfickerGame game = sapper as Virus;
            Console.WriteLine(op);
            Console.WriteLine(game);
            Software soft = new Software();
            Console.WriteLine(soft.ToString());
            CConfickerGame bomber = new Sapper(2000, "2D", "Awalar");
            CConfickerGame warzone = new Sapper(2019, "Battle Royale", "Epic Games");
            CConfickerGame cloner = new Virus(1971, "replicant", "Bob Thomas");
            CConfickerGame macro = new Virus(1999, "macro", "Unknown");
            dynamic[] PrinterArr = {bomber, warzone, cloner, macro};
            Console.WriteLine("PRINTER");
            foreach (var item in PrinterArr)
            {
                Console.WriteLine(Printer.IAmPrinting(item));
            }
            Console.ReadKey();
        }
    }

    interface IOperationList
    {
        List<string> operations { get; set; }
    }

    interface ITextEditor
    {
        string name { get; set; }
        string type { get; set; }
    }

    class Software : ITextEditor
    {
        public string name { get; set; }
        public string type { get; set; }
        public string creator { get; set; }
        public int YearOfRelease { get; set; }

        public override string ToString()
        {
            return "ITextEditor.Software";
        }
    }

    sealed class Word : Software, IOperationList
    {
        public string name { get; set; }
        public string type { get; set; }
        public string creator { get; set; }
        public int YearOfRelease { get; set; }
        public List<string> operations { get; set; }
        public override string ToString()
        {
            return "Software.Word IOperationList.Word";
        }
    }

    abstract class CConfickerGame
    {
        public int YearOfRelease { get; set; }
        public string GameType { get; set; }
        public string Creator { get; set; }

        public CConfickerGame(int year, string type, string creator)
        {
            YearOfRelease = year;
            GameType = type;
            Creator = creator;
        }

        public virtual void Display()
        {
            Console.WriteLine($"Game type: {GameType}\nYear: {YearOfRelease}\n Creatort: {Creator}");
        }
        public abstract override string ToString();
    }

    class Sapper : CConfickerGame, IOperationList
    {
        public List<string> operations { get; set; }
        public Sapper(int year, string type, string creator) : base(year, type, creator)
        {
        }

        public override void Display()
        {
            Console.WriteLine($"Release Year: {YearOfRelease}\nType: {GameType}\nCreator: {Creator}");
        }
        public override string ToString()
        {
            return "CConfickerGame.Sapper";
        }
    }

    class Virus : CConfickerGame, IOperationList
    {
        public List<string> operations { get; set; }

        public Virus(int year, string type, string creator) : base(year, type, creator)
        {
        }

        public override string ToString()
        {
            return "CConfickerGame.Virus";
        }
    }

    static class Printer
    {
        static internal string IAmPrinting(object obj)
        {
            if (obj is CConfickerGame)
            {
                if (obj is Sapper)
                {
                    CConfickerGame s = obj as Sapper;
                    return Convert.ToString(s);
                }

                if (obj is Virus)
                {
                    CConfickerGame v = obj as Virus;
                    return Convert.ToString(v);
                }
                CConfickerGame ccg = obj as CConfickerGame;
                return Convert.ToString(ccg);
            }
            return "Error";
        }
    }
}