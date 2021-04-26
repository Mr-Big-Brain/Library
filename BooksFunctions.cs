using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Books_dot_net_console
{
    class BooksFunctions
    {
        public void SortBooks(List<Book> book, int filter)
        {
            if(book!=null)
            {
                if (filter == 1)
                {
                    book.Sort(delegate (Book x, Book y) {
                        return x.author.CompareTo(y.author);
                    });
                }
                else if (filter == 2)
                {
                    book.Sort(delegate (Book x, Book y) {
                        return x.category.CompareTo(y.category);
                    });
                }
                else if (filter == 3)
                {
                    book.Sort(delegate (Book x, Book y) {
                        return x.language.CompareTo(y.language);
                    });
                }
                else if (filter == 4)
                {
                    book.Sort(delegate (Book x, Book y) {
                        return x.isbn.CompareTo(y.isbn);
                    });
                }
                else if (filter == 5)
                {
                    book.Sort(delegate (Book x, Book y) {
                        return x.name.CompareTo(y.name);
                    });
                }
            }
            
        }
        public void PrintAllBooks(List<Book> book, int filter)
        {
            bool do_we_have_any_data = false;
            if (filter == 1)
            {
                if(book!=null)
                for (int i = 0; i < book.Count; i++)
                {
                    if (book[i].owner == 0)
                    {
                        book[i].Output();
                        do_we_have_any_data = true;
                    }
                }
            }
            if (filter == 2)
            {
                if (book != null)
                    for (int i = 0; i < book.Count; i++)
                {
                    if (book[i].owner != 0)
                    {
                        book[i].Output();
                        do_we_have_any_data = true;
                    }

                }
            }
            if (do_we_have_any_data == false)
            {
                Console.Write("Sorry, there is no books in this category \n");
            }
        }
        public void Remove_book(List<Book> book)
        {
            if (book != null)
            {
                Console.Write("Please enter books ISBN \n");
                bool found = false;
                string isbn = Console.ReadLine();
                for (int i = 0; i < book.Count; i++)
                {
                    if (book[i].isbn == isbn)
                    {
                        book.RemoveAt(i);
                        found = true;
                        break;
                    }
                }
                if (found == true)
                {
                    Console.Write("Book was succesfully removed from library");
                }
                else
                {
                    Console.Write("There is no book with this ISBN");
                }
            }
            else
            {
                Console.Write("There is no books in the library at the moment. Please try again later \n");
            }
        }
    }

}
