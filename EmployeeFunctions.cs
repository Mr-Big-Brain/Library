using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books_dot_net_console
{
    class EmployeeFunctions
    {
        public void GenerateFromBooks(List<Book> book, Dictionary<int, int> emp)
        {
            if (book != null)
            {
                for (int i = 0; i < book.Count; i++)
                {
                    if (book[i].owner != 0)
                    {
                        if (emp.ContainsKey(book[i].owner))
                        {
                            emp[book[i].owner]++;
                        }
                        else
                        {
                            emp[book[i].owner] = 1;
                        }
                    }
                }
            }
        }
        public void GenerateEmployeeIfNotExist(Dictionary<int, int> emp, int id)
        {
            if (!emp.ContainsKey(id))
            {
                emp[id] = 0;
            }
        }
    }
}
