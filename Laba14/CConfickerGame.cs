using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json.Serialization;

namespace Laba14
{
    interface IOperationList
    {
        List<string> operations { get; set; }
    }
    [Serializable]
    public abstract class CConfickerGame
    {
        [XmlIgnore]
        [JsonIgnore]
        [SoapIgnore]
        public int YearOfRelease { get; set; }
        public string GameType { get; set; }
        public string Creator { get; set; }

        public CConfickerGame(int year, string type, string creator)
        {
            YearOfRelease = year;
            GameType = type;
            Creator = creator;
        }
        public CConfickerGame()
        {}
        public virtual void Display()
        {
            Console.WriteLine($"Game type: {GameType}\nYear: {YearOfRelease}\n Creator: {Creator}");
        }
        public abstract override string ToString();
    }
    [Serializable]
    public class Sapper : CConfickerGame, IOperationList
    {
        public List<string> operations { get; set; }
        public Sapper(int year, string type, string creator) : base(year, type, creator)
        {
        }

        public Sapper()
        {}
        public override void Display()
        {
            Console.WriteLine($"Release Year: {YearOfRelease}\nType: {GameType}\nCreator: {Creator}");
        }
        public override string ToString()
        {
            return "CConfickerGame.Sapper";
        }
    }
}