using System;

namespace LibraryCatalog
{
    internal class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }
        public bool IsBorrowed { get; set; }

        public Book()
        {
            ISBN = "";
            Title = "";
            Author = "";
            YearPublished = 0;
            IsBorrowed = false;
        }

        public Book(string isbn, string title)
        {
            ISBN = isbn;
            Title = title;
            Author = "";
            YearPublished = 0;
            IsBorrowed = false;
        }

        public Book(string isbn, string title, string author, int year)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
            YearPublished = year;
            IsBorrowed = false;
        }

        public string Borrowly()
        {
            if (IsBorrowed)
                return "Already Borrowed";

            IsBorrowed = true;
            return "Borrowed";
        }

        public string Returnly()
        {
            if (!IsBorrowed)
                return "Not Borrowed";

            IsBorrowed = false;
            return "Available";
        }

        public string GetDetails()
        {
            return $"{ISBN} | {Title} | {Author} | {YearPublished}";
        }
    }
}