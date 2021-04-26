using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;

namespace Books_dot_net_console
{   
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            Dictionary<int, int> employee = new Dictionary<int, int>();
            int choice;
            
            FileManagement Filemanager = new FileManagement();          //*
            BooksFunctions BookFunc = new BooksFunctions();             //**
            UserInterface UI = new UserInterface();                     //*** our methods
            EmployeeFunctions EmpFunc = new EmployeeFunctions();        //**
            DateFunctions DateFunc = new DateFunctions();               //*

            books = JsonConvert.DeserializeObject<List<Book>>(Filemanager.Readfile("Books_Data_Base.json")); //Reading saved books from .json file

            EmpFunc.GenerateFromBooks(books, employee); //generates dictionary for emloyee from our json file with books
            UI.Greetings(); //Says hello for a first time
            
            while (true) //Maybe I should made class choice, but i think it would be harder to navigate through my code
            {
                UI.Menu(); //Shows us what we can choose
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1) //********************************************Add book to library case
                {
                    if (books == null)
                    {
                        books = new List<Book>(); //yup, this looks strange, but it works
                    }

                    Book Book_to_add = new Book();      
                    Book_to_add.Add_new_book();         
                    books.Add(Book_to_add);             
                }
                else if (choice == 2) //***************************************Take book from library case
                {
                    bool employee_can_take_book = true;
                    int id;

                    Console.Write("Please enter your ID: \n");
                    id = Convert.ToInt32(Console.ReadLine());
                    EmpFunc.GenerateEmployeeIfNotExist(employee, id);

                    if (employee[id] == 3)
                    {
                        Console.WriteLine("Sorry, but you already reading 3 books, you cant take one more :/\n");
                        employee_can_take_book = false;
                    }

                    if (employee_can_take_book == true)
                    {
                        Console.WriteLine("Please enter ISBN of a book\n");
                        string isbn = Console.ReadLine();
                        bool exists = false;
                        if(books!=null) /////////////////////////////////////////////////////////
                        for (int i = 0; i < books.Count; i++)
                        {
                            if (books[i].isbn == isbn)
                            {
                                exists = true;
                                if (books[i].owner != 0)
                                {
                                    Console.WriteLine("Someone owns this book at the moment, sorry, try to take it later :)\n");
                                }
                                else
                                {
                                    int booksid = i;
                                    DateFunc.AskEmployeeWhenReturn(books, employee, id, booksid); //Asks user about date when he wants to return 
                                }                                                                 //a book and decides if it can be given
                                break;
                            }
                        }
                        if (exists == false)
                        {
                            Console.WriteLine("The ISBN of a book is incorrect, please try again\n");
                        }
                    }
                }
                else if (choice == 3) //****************************************book return case
                {
                    bool found = false;
                    string isbn;

                    Console.Write("Enter books ISBN\n");
                    isbn = Console.ReadLine();

                    if(books!=null)
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (books[i].isbn == isbn)
                        {
                            books[i].owner = 0;
                            if (DateTime.Compare(books[i].date_of_return, DateTime.Today) == -1)
                            {
                                Console.Write("Please return books when you promised, or you will get a curse of bugged code\n"); //probably I completed task to write funny message(*sad Harold meme*)
                            }
                            found = true;
                            break;
                        }
                    }
                    
                    if (found == false)
                    {
                        Console.Write("There is no book with this isbn\n");
                    }
                    else
                    {
                        Console.Write("Book was successfully returned\n");
                    }
                }
                else if (choice == 4) //****************************************List all books case
                {
                    int book_availability;
                    int filterchoice;

                    Console.WriteLine("Choose: \n 1. Available books \n 2. Taken books");
                    book_availability = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Now choose your filter \n 1. By author \n 2. By category \n 3. By language \n 4. By ISBN \n 5. By name");
                    filterchoice = Convert.ToInt32(Console.ReadLine());

                    BookFunc.SortBooks(books, filterchoice); //sorts books by chosen filter

                    UI.PrintFilterCategories();

                    BookFunc.PrintAllBooks(books, book_availability);
                }
                else if (choice == 5) //*****************************************Removing a book case
                {
                    BookFunc.Remove_book(books); //removes book from library if it exists
                }
                else if (choice == 6)//******************************************Save case. If you dont use this button, you wont save anything
                {
                    Filemanager.Save("Books_Data_Base.json", books); //Saves books in .json file
                    break;
                }
                else
                {
                    Console.Write("You entered a wrong number, please try again\n"); //works if you accidentally pressed a wrong number(please dont enter characters ;D)
                }
            }
        }
    }
}
//If you are bored you can read this :D
//Time consumed:
//reading about what is .NET - 15 min
//right programs to work with .NET finding and downloading ~ 30 min
//watching how to create correct .NET core file on Visual studio ~ 15min
//understanding that I cant or I dont know how to use c++ in .NET CORE application ~ 15 min
//started creating 00:12
//first class created 00:35
//learning how to read integers 1:07
//probably I managed to create books array 1:18
//googling how to add webform in visual studio for JSON file 1:24
//accidently found out how to create JSON file 1:29 
//still trying to understand how to correctly create an array of books 1:48
//youtube helped me !!!!! 2:05
//trying to find Json.net in Visual Studio 2:12
//still no success 2:18
//found it in Nugget Packages 2:24
//JSON convert doesnt want to work :/ 2:37
//made all Book class variables public, now JsonConvert function works well 2:42
//understood that i need something like vector in c++ in order to delete books 2:43
//break time 2:45 - 3:27
//decided to make list data type for books 3:34
//made it 3:42
//still some troubles with json 4:18
//break 4:18 - 22:05
//Learned more about JSON 22:30
//Managed to add new book to list and JSON 22:48
//break 22:48 - 23:32
//making all string variables same size to make them look well when we want to see them 23:47 
//fixing a bug when I cant add book to empty library 00:08
//fixed it 0:47
//googling how Dictionary works 1:03
//break 1:03 = 1:21
//from this moment I forgot to write these logs