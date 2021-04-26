using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_dot_net_console
{
    public class Book
    {
        public string name { get; set; }
        public string author { get; set; }
        public string category { get; set; }
        public string language { get; set; }
        public int publication_date { get; set; }
        public string isbn { get; set; }
        public int owner = 0;
        public DateTime date_of_return { get; set; }
        public void Add_new_book()
        {
            Console.Write("Enter book name: ");
            name = Console.ReadLine();
            Console.Write("Enter book author: ");
            author = Console.ReadLine();
            Console.Write("Enter book category: ");
            category = Console.ReadLine();
            Console.Write("Enter book language: ");
            language = Console.ReadLine();
            Console.Write("Enter book publication year: ");
            publication_date = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter isbn: ");
            isbn = Console.ReadLine();
        }
        public void Add_owner(int id)
            {
            owner = id;
            }
        public void Owner_return()
            {
            owner = 0;
            }
        public void Output()
        {
            Console.Write(name + new string(' ', 35 - name.Length) + author + new string(' ', 35 - author.Length) + category + new string(' ', 25 - category.Length) + language + new string(' ', 20 - language.Length) + publication_date + new string(' ', 22) + isbn + "\n");
        }
    }
}
