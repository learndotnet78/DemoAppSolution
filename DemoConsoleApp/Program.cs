using DemoConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DemoConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Applied hotfix
            WriteXMLViaLINQ();
            Console.ReadLine();
        }

        public static void ReadXmlFile()
        {
            string xmlFileLocation = @"E:\\FileLocation\\NewBook.xml";
            XmlTextReader xmlReader = new XmlTextReader(xmlFileLocation);

            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:   
                        Console.Write("<" +xmlReader.Name);
                        while (xmlReader.MoveToNextAttribute())
                        {
                            Console.Write(" " + xmlReader.Name + "='" + xmlReader.Value + "'");
                        }
                        Console.Write(">");
                        Console.WriteLine();
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine(xmlReader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        Console.Write("</" + xmlReader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }

        }

        public static void ReadXmlFileViaLINQ()
        {
            XDocument xmlDoc = XDocument.Load(@"E:\\FileLocation\\NewBook.xml");

            var items = from x in xmlDoc.Descendants("catalog").Descendants("book")
                        select new
                        {
                            Author = x.Element("author").Value,
                            Title = x.Element("title").Value,
                            Price = x.Element("price").Value,
                            Location = from y in x.Descendants("location")
                                       select new
                                       {
                                           Shelf = y.Element("shelf").Value
                                       }
                        };
            foreach (var item in items)
            {
                Console.WriteLine($"Author - {item.Author}");
                foreach (var location in item.Location)
                {
                    Console.Write($"Shelf - {location.Shelf}");
                }
                Console.WriteLine();
            }
        }

        public static void WriteXMlFile()
        {
            XmlWriter xmlWriter = XmlWriter.Create(@"E:\\FileLocation\\OutputXmlFile.xml");

            List<Book> books = BuildBookData();
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Books");
            foreach (var book in books)
            {
                xmlWriter.WriteStartElement("Book");
                xmlWriter.WriteAttributeString("BookID", book.BookID.ToString());
                xmlWriter.WriteElementString("Title", book.Title);
                xmlWriter.WriteElementString("Author", book.Author);
                xmlWriter.WriteElementString("Price", book.Price.ToString());
                foreach (var booklocations in book.Locations)
                {
                    xmlWriter.WriteStartElement("Location");
                    xmlWriter.WriteElementString("Shelf", booklocations.Shelf);
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        private static List<Book> BuildBookData()
        {
            return new List<Book>()
            {
                new Book() { BookID = 1, Author ="Author1", Price = 10, Title="Title 1",
                Locations = new List<Location>() {
                        new Location() { Shelf = "S1"},
                        new Location() { Shelf = "S2"}
                  }
                },
                new Book() { BookID = 2, Author ="Author2", Price = 20, Title="Title 2",
                                Locations = new List<Location>() {
                        new Location() { Shelf = "S3"},
                        new Location() { Shelf = "S4"}
                  }
                },
                new Book() { BookID = 3, Author ="Author3", Price = 30, Title="Title 3",
                                Locations = new List<Location>() {
                        new Location() { Shelf = "S5"},
                        new Location() { Shelf = "S6"}
                  }
                },
            };
        }

        public static string WriteXMLViaLINQ()
        {
            List<Book> books = BuildBookData();

            var outputXML = new XDocument(
                    new XElement("Catalog",
                    from book in books
                    select new XElement("Book",
                    new XElement("Author", book.Author),
                    new XElement("Title", book.Title),
                    new XElement("Price", book.Price),
                    from location in book.Locations
                    select new XElement("Location",
                    new XElement("Shelf", location.Shelf))
                    )
                ));

            return outputXML.ToString();
        }
        public static void FindGreaterNumber()
        {
            int a = 155;
            int b = 45;
            int c = 87;

            Console.WriteLine((a > b) ? (a > c ? a : c) : (b > c ? b : c));
            Console.ReadLine();
        }
        public static void NewMethod()
        {
            while (true)
            {
                Console.WriteLine("Input Value");
                int i = Convert.ToInt16(Console.ReadLine());
                SwitchCaseforMonths(i);
            }
            Console.ReadLine();
        }

        public static void SwitchCaseforMonths(int monthValue)
        {
            switch(monthValue)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    Console.WriteLine("31 days");
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    Console.WriteLine("30 days");
                    break;
                case 2:
                    Console.WriteLine("28/29 days");
                    break;
            }
        }

        public static void AsyncMethod()
        {
            Console.WriteLine("Async execution started");
            CallMethod();
            Method2();
            Console.WriteLine("Main method end reached");
            Console.ReadLine();
        }
        public static async void CallMethod()
        {
            var count = await Method1();
        }
        public static async Task<int> Method1()
        {
            int cnt = 0;

            await Task.Run(() =>
            {
                for (int i = 0; i < 200000; i++)
                {
                    if (i == 10000)
                    {
                        Console.WriteLine($"Async execution end and value of i is {i}");
                    }
                    cnt += 1;
                }
            });

            return cnt;
        }

        public static void Method2()
        {
            Console.WriteLine("Method 2 reached");

        }
    }


}
