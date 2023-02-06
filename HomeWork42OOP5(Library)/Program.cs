using System;
using System.Collections.Generic;

namespace HomeWork42OOP5_Library_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();

            storage.Work();
        }
    }

    class Book
    {
        public Book(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Название книги - {Title}, автор - {Author}, год выпуска - {Year}.\n");
        }
    }

    class Storage
    {
        private List<Book> _books = new List<Book>();

        public void Work()
        {
            const string AddBookCommand = "1";
            const string RemoveBookCommand = "2";
            const string ShowAllBooksCommand = "3";
            const string ShowBooksCommand = "4";
            const string ExitCommand = "5";

            bool isOpen = true;

            while (isOpen)
            {
                ShowMenu(AddBookCommand, RemoveBookCommand, ShowAllBooksCommand, ShowBooksCommand, ExitCommand);

                Console.Write("Ваш выбор: ");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case AddBookCommand:
                        AddBook();
                        break;

                    case RemoveBookCommand:
                        RemoveBook();
                        break;

                    case ShowAllBooksCommand:
                        ShowAllBooks();
                        break;

                    case ShowBooksCommand:
                        ShowBooks();
                        break;

                    case ExitCommand:
                        isOpen = false;
                        break;

                    default:
                        break;
                }
            }
        }

        private void ShowMenu(string AddBookCommand, string RemoveBookCommand, string ShowAllBooksCommand, string ShowBooksCommand, string ExitCommand)
        {
            Console.Clear();
            Console.WriteLine($"     Добро пожаловать в хранилище книг");
            Console.WriteLine($"{new string('_', 50)}\n");
            Console.WriteLine($"Для добавления новой книги нажмите --------- {AddBookCommand}\n");
            Console.WriteLine($"Для удаления книги нажмите ----------------- {RemoveBookCommand}\n");
            Console.WriteLine($"Показать все книги нажмите ----------------- {ShowAllBooksCommand}\n");
            Console.WriteLine($"Показать книги по... нажмите --------------- {ShowBooksCommand}\n");
            Console.WriteLine($"Выйти из хранилища нажмите ----------------- {ExitCommand}\n");
            Console.WriteLine($"{new string('_', 50)}\n");
        }

        private void AddBook()
        {
            Console.Clear();
            Console.WriteLine("Добавление новой книги");
            Console.WriteLine($"{new string('_', 50)}");
            Console.Write("\nВведите название книги: ");
            string title = Console.ReadLine();

            Console.Write("\nВведите фамилию автора: ");
            string author = Console.ReadLine();

            int year = ParseNumber("\nВведите год издания: ");

            _books.Add(new Book(title, author, year));

            Console.Write("\nНажмите любую клавишу");
            Console.ReadKey();
        }

        private void RemoveBook()
        {
            bool isFined = true;

            Console.Clear();
            Console.WriteLine("               Удаление книги");
            Console.WriteLine($"{new string('_', 50)}");
            int userInput = ParseNumber("\nВведите порядковый номер книги: ");

            for (int i = 0; i < _books.Count; i++)
            {
                if (userInput - 1 == i)
                {
                    _books.RemoveAt(i);
                    isFined = true;
                    break;
                }
                else
                {
                    isFined = false;
                }
            }

            if (isFined)
                Console.WriteLine("\nКнига удалена");
            else
                Console.WriteLine("\nТакой книги нет. Попробуйте снова.");

            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadKey();
        }

        private void ShowAllBooks()
        {
            Console.Clear();
            Console.WriteLine("               Все книги в хранилище:");
            Console.WriteLine($"{new string('_', 50)}\n");

            for (int i = 0; i < _books.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _books[i].ShowInfo();
            }

            Console.Write("Нажмите любую клавишу");
            Console.ReadKey();
        }

        private void ShowBooks()
        {
            const string ShowByTitleCommand = "1";
            const string ShowByAuthorCommand = "2";
            const string ShowByYearCommand = "3";

            Console.Clear();
            Console.WriteLine("             Показать книги по...");
            Console.WriteLine($"{new string('_', 50)}\n");
            Console.WriteLine($"Показать книги по названию нажмите --------- {ShowByTitleCommand}\n");
            Console.WriteLine($"Показать книги по автору нажмите ----------- {ShowByAuthorCommand}\n");
            Console.WriteLine($"Показать книги по году издания нажмите ----- {ShowByYearCommand}\n");
            Console.WriteLine($"{new string('_', 50)}\n");

            Console.Write("Ваш выбор: ");
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case ShowByTitleCommand:
                    ShowByTitle();
                    break;

                case ShowByAuthorCommand:
                    ShowByAuthor();
                    break;

                case ShowByYearCommand:
                    ShowByYear();
                    break;
            }
        }

        private void ShowByTitle()
        {
            bool isFined = false;

            Console.Clear();
            Console.WriteLine("Показать книги по названию");
            Console.WriteLine($"{new string('_', 50)}\n");

            Console.Write("Введите название книги: ");
            string userInput = Console.ReadLine();

            Console.WriteLine();

            for (int i = 0; i < _books.Count; i++)
            {
                if (userInput.ToLower() == _books[i].Title.ToLower() || _books[i].Title.Contains(userInput))
                {
                    _books[i].ShowInfo();
                    isFined = true;
                }
            }

            if (isFined == false)
                Console.WriteLine("Такой книги нет");

            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadKey();
        }

        private void ShowByAuthor()
        {
            bool isFined = false;

            Console.Clear();
            Console.WriteLine("Показать книги по автору");
            Console.WriteLine($"{new string('_', 50)}\n");

            Console.Write("Введите автора книг: ");
            string userInput = Console.ReadLine();

            Console.WriteLine();

            for (int i = 0; i < _books.Count; i++)
            {
                if (userInput.ToLower() == _books[i].Author.ToLower() || _books[i].Author.Contains(userInput))
                {
                    _books[i].ShowInfo();
                    isFined = true;
                }
            }

            if (isFined == false)
                Console.WriteLine("Такой книги нет");

            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadKey();
        }

        private void ShowByYear()
        {
            bool isFined = false;

            Console.Clear();
            Console.WriteLine("Показать книги по году издания");
            Console.WriteLine($"{new string('_', 50)}\n");

            int userInput = ParseNumber("\nВведите год издания книг: ");

            Console.WriteLine();

            for (int i = 0; i < _books.Count; i++)
            {
                if (userInput == _books[i].Year)
                {
                    _books[i].ShowInfo();
                    isFined = true;
                }
            }

            if (isFined == false)
                Console.WriteLine("Такой книги нет");

            Console.WriteLine("\nНажмите любую клавишу");
            Console.ReadKey();
        }

        private int ParseNumber(string value)
        {
            int number;

            Console.Write(value);
            string userInput = Console.ReadLine();

            while (int.TryParse(userInput, out number) == false)
            {
                Console.Write("\nВведено не чиcло. Введите только целое число: ");
                userInput = Console.ReadLine();
            }

            return number;
        }
    }
}
