using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsoleApp.Model
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public List<Location> Locations { get; set; }
    }
}
