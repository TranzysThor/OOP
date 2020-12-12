using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml;

namespace Laba14
{
    public static class Serializator
    {
        public static void XML()
        {
            Sapper sapper = new Sapper(2000, "TMMLP", "Em");
            XmlSerializer formatter = new XmlSerializer(typeof(Sapper));
            using (FileStream fs = new FileStream("sapper.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, sapper);
            }

            using (FileStream fs = new FileStream("sapper.xml", FileMode.OpenOrCreate))
            {
                Sapper newsapp = (Sapper) formatter.Deserialize(fs);
                Console.WriteLine("Deserialization via XML:");
                Console.WriteLine($"Type: {newsapp.GameType}\n" +
                                  $"Creator: {newsapp.Creator}");
            }
        }

        public static void JSON()
        {
            Sapper sapper = new Sapper(2000, "TMMLP", "Em");
            using (FileStream fs = new FileStream("sapper.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync(fs, sapper);
            }

            string json = File.ReadAllText("sapper.json");
            Sapper newsapp = JsonSerializer.Deserialize<Sapper>(json);
            Console.WriteLine("Deserialization via JSON");
            Console.WriteLine($"Type: {newsapp.GameType}\n" +
                              $"Creator: {newsapp.Creator}");   
        }
        public static void SOAP()
        {
            Sapper sapper = new Sapper(2000, "TMMLP", "Em");
            SoapFormatter soap = new SoapFormatter();
            using (FileStream fs = new FileStream("sapper.soap", FileMode.OpenOrCreate))
            {
                soap.Serialize(fs, sapper);
            }

            using (FileStream fs = new FileStream("sapper.soap", FileMode.OpenOrCreate))
            {
                Sapper newsapp = (Sapper) soap.Deserialize(fs);
                Console.WriteLine("Deserialization via SOAP");
                Console.WriteLine($"Type: {newsapp.GameType}\n" +
                                  $"Creator: {newsapp.Creator}");
            }
        }

        public static void Binary()
        {
            Sapper sapper = new Sapper(2000, "TMMLP", "Em");
            BinaryFormatter bin = new BinaryFormatter();
            using (FileStream fs = new FileStream("sapper.dat", FileMode.OpenOrCreate))
            {
                bin.Serialize(fs, sapper);
            }

            using (FileStream fs = new FileStream("sapper.dat", FileMode.OpenOrCreate))
            {
                Sapper newsapp = (Sapper) bin.Deserialize(fs);
                Console.WriteLine("Deserialization via Binary");
                Console.WriteLine($"Type: {newsapp.GameType}\n" +
                                  $"Creator: {newsapp.Creator}");
            }
        }

        public static void ArraySerialization()
        {
            Sapper sapper1 = new Sapper(2000, "TMMLP", "Em");
            Sapper sapper2 = new Sapper(2002, "TES", "Em");
            Sapper sapper3 = new Sapper(2010, "Recovery", "Em");
            Sapper[] sappers = {sapper1, sapper2, sapper3};
            using (FileStream fs = new FileStream("sappers.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync(fs, sappers);
            }
            string json = File.ReadAllText("sappers.json");
            Sapper[] newSappers = JsonSerializer.Deserialize<Sapper[]>(json);
            Console.WriteLine(json);
            foreach (var sap in newSappers)
            {
                Console.WriteLine($"Type: {sap.GameType}\n" +
                                  $"Creator: {sap.Creator}");
            }
        }

        public static void xPath()
        {
            Sapper sapper1 = new Sapper(2000, "TMMLP", "Em");
            Sapper sapper2 = new Sapper(2002, "TES", "Em");
            Sapper sapper3 = new Sapper(2010, "Recovery", "Em");
            Sapper[] sappers = {sapper1, sapper2, sapper3};
            XmlSerializer formatter = new XmlSerializer(typeof(Sapper[]));
            using (FileStream fs = new FileStream("sappers.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, sappers);
            }
            XmlDocument xml = new XmlDocument();
            xml.Load("sappers.xml");
            XmlElement xRoot = xml.DocumentElement;
            XmlNodeList outer = xRoot.SelectNodes("*");
            foreach (XmlNode node in outer)
            {
                Console.WriteLine(node.OuterXml);
            }
            XmlNodeList nodes = xRoot.SelectNodes("//Sapper/GameType");
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine($"Type: {node.InnerText}");
            }
        }

        public static void LtoX()
        {
            XDocument xdoc = new XDocument(new XElement("Sappers",
                new XElement("Sapper",
                    new XElement("GameType", "TMMLP2"),
                    new XElement("Creator", "Em")),
                new XElement("Sapper",
                    new XElement("GameType", "Shady XV"),
                    new XElement("Creator", "Em")),
                new XElement("Sapper",
                    new XElement("GameType", "Revival"),
                    new XElement("Creator", "Em"))));
            xdoc.Save("LINQsappers.xml");
        }
    }
}