using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using static System.Console;

namespace Ch10_Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] callsigns = new string[] {"Husker", "Starbuck", "Apollo", "Boomer", "Bulldog", "Athena", "Helo", "Racetrack" };
            string textFile = @"D:\work\repos\carte\Ch10_Streams.txt";
            StreamWriter text = File.CreateText(textFile);

            foreach (string item in callsigns)
            {
                text.WriteLine(item);
            }
            text.Dispose();

            WriteLine($"{textFile} contains {new FileInfo(textFile).Length} bytes.");
            WriteLine(File.ReadAllText(textFile));

            string xmlFile = @"D:\work\repos\carte\Ch10_Streams.xml";
            FileStream xmlFileStream = File.Create(xmlFile);
            XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true});
            xml.WriteStartDocument();
            xml.WriteStartElement("callsigns");
            foreach (string item in callsigns)
            {
                xml.WriteElementString("callsign", item);
            }
            xml.WriteEndElement();
            xml.Dispose();
            xmlFileStream.Dispose();

            WriteLine($"{xmlFile} contains {new FileInfo(xmlFile).Length} bytes");
            WriteLine(File.ReadAllText(xmlFile));
        }
    }
}
