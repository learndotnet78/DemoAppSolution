using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DemoConsoleApp.Model
{
    public class FileIOClass
    {
        public FileIOClass()
        {
            
        }

        public void GetAllFilesFromDirectory()
        {
            FileInfo[] files = GetAllFiles(@"E:\FileLocation");
            foreach (var file in files)
            {
                Console.WriteLine(file.FullName);
            }


        }
        FileInfo[] GetAllFiles(string path)
        {
            return new DirectoryInfo(path).GetFiles("*.txt");
        }

        public void ReadAndWriteFile()
        {
            FileInfo[] files = GetAllFiles(@"E:\FileLocation");
            var outputPath = "E:\\FileProcessLocation\\Output\\OutputFile.txt";

            foreach (var file in files)
            {
                string[] dataRead = File.ReadAllLines(file.FullName);
                File.AppendAllLines(outputPath, dataRead);
            }

        }

        public void ReadXmlFile()
        {
            string xmlFileLocation = @"E:\\FileLocation\\NewBook.xml";
            XmlTextReader xmlReader = new XmlTextReader(xmlFileLocation);

            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.WriteLine("<" + xmlReader.Name + ">");
                        break;
                    case XmlNodeType.Text:
                        Console.WriteLine(xmlReader.Value);
                        break;
                    case XmlNodeType.EndElement:
                        Console.WriteLine("</" + xmlReader.Name + ">");
                        break;
                }
            }
        }

        public void ReadXmlFileViaLINQ()
        {
            XDocument xDocument = XDocument.Load(@"E:\\FileLocation\\NewBook.xml");
            var books = from x in xDocument.Descendants("catalog").Descendants("book")
                        select new Book
                        {
                            Author = x.Element("author").Value,
                            Title = x.Element("title").Value,
                            Price = Convert.ToDecimal(x.Element("price").Value),
                        };

            foreach (var item in books)
            {
                Console.WriteLine($"Author - {item.Author}");
                Console.WriteLine($"Title - {item.Title}");
                Console.WriteLine($"Price - {item.Price}");
                Console.WriteLine();
            }
        }

        public void WriteXmlFile()
        {
            XmlWriter xmlWriter = XmlWriter.Create(@"E:\\FileLocation\\OutputXmlFile.xml");
            List<Book> books = BuildBookData();

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("catalog");
            foreach (var book in books)
            {
                xmlWriter.WriteStartElement("books");
                xmlWriter.WriteElementString("BookID", Convert.ToString(book.BookID));
                xmlWriter.WriteElementString("Author", Convert.ToString(book.Author));
                xmlWriter.WriteElementString("Title", Convert.ToString(book.Title));
                xmlWriter.WriteElementString("Price", Convert.ToString(book.Price));
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

        }

        public void WriteXmlFileViaLINQ()
        {
            XmlWriter xmlWriter = XmlWriter.Create(@"E:\\FileLocation\\NewOutputXmlFile.xml");
            List<Book> books = BuildBookData();
            var outputXML = new XDocument(
                new XElement("catalog",
                from book in books
                select new XElement("Book",
                    new XElement("Author", book.Author),
                    new XElement("Title", book.Title),
                    new XElement("Price", book.Price)
                )
                )
                );

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteString(outputXML.ToString());
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

    }
}
