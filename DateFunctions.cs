using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_dot_net_console
{
    class DateFunctions
    {
        public void AskEmployeeWhenReturn(List<Book> book, Dictionary<int, int> emp,int empid,int bookid)
        {
            int month, day;
            DateTime today = DateTime.Today;
            DateTime maximum_date_to_return = today.AddDays(60);
            
            Console.WriteLine("Please enter\nMonth when you want to return this book");
            month = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Day of a month when you are going to return a book");
            day = Convert.ToInt32(Console.ReadLine());

            DateTime when_employee_return_book = new DateTime(DateTime.Today.Year, month, day);

            if (DateTime.Compare(when_employee_return_book, today) == -1)
            {
                when_employee_return_book = when_employee_return_book.AddYears(1);
            }

            if (DateTime.Compare(maximum_date_to_return, when_employee_return_book) == 1)
            {
                Console.WriteLine("You took this book");
                book[bookid].Add_owner(empid);
                book[bookid].date_of_return = when_employee_return_book;
                emp[empid]++;
            }
            else
            {
                Console.WriteLine("You cant take this book for such long period");
            }
        }
    }
}
