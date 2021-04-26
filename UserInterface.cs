using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_dot_net_console
{
    class UserInterface
    {
        public void Greetings()
        {
            Console.WriteLine("Welcome to our library");
            Console.WriteLine("What would you like to do today?");
        }
        public void Menu()
        {
            Console.Write("Press\n");
            Console.Write("1 to add a new book\n");
            Console.Write("2 to take a book from library\n");
            Console.Write("3 to return a book\n");
            Console.Write("4 to list all the books\n");
            Console.Write("5 to delete a book from library\n");
            Console.Write("6 to Save and exit\n");
        }
        public void PrintFilterCategories() //by the way I consider that ISBN will be 13 chars long
        {
            Console.WriteLine(
                        "Name" + new string(' ', 31)
                        + "Author" + new string(' ', 29)
                        + "Category" + new string(' ', 17)
                        + "Language" + new string(' ', 12)
                        + "Publication year" + new string(' ', 10)
                        + "ISBN");
        }
    }
}
