namespace _8_lesson_oop_advansed_sealid_static_class
{

    /*    public class Library
        {
            private Shelf[] Shelves { get; }

            public Library()
            {
                Shelves = new Shelf[]
                {
                new Shelf(3, 30),
                     Add more shelves if needed
                };
        }

        public void AddBook(
            Book book,
            int shelf,
            int floor,
            int closet,
            int javon)
        {
            Shelves[shelf - 1].Add(book, floor - 1, closet - 1, javon - 1);
        }

        public bool ContainsBook(Book book, int shelf, int floor, int closet, int javon)
        {
            return Shelves[shelf - 1].Contains(book, floor - 1, closet - 1, javon - 1);
        }

        public string GetBooks()
        {
            StringBuilder result = new StringBuilder();
            foreach (Shelf shelf in Shelves)
            {
                result.Append(shelf.GetBooks());
            }
            return result.ToString();
        }

        public int GetFloor(Book book)
        {
            foreach (Shelf shelf in Shelves)
            {
                int floor = shelf.GetFloor(book);
                if (floor != -1)
                {
                    return floor;
                }
            }
            return -1;
        }

        public int GetCloset(Book book)
        {
            foreach (Shelf shelf in Shelves)
            {
                int closet = shelf.GetCloset(book);
                if (closet != -1)
                {
                    return closet;
                }
            }
            return -1;
        }

        public int GetShelf(Book book)
        {
            foreach (Shelf shelf in Shelves)
            {
                int javon = shelf.GetShelf(book);
                if (javon != -1)
                {
                    return javon;
                }
            }
            return -1;
        }

        public Book? FindBook(string authorName, string title)
        {
            foreach (Shelf shelf in Shelves)
            {
                Book book = shelf.Find(authorName, title);
                if (book != null)
                {
                    return book;
                }
            }
            return null;
        }

        public Library(string author, string bookName, string[][][] books)
        {
            this.author = author;
            this.bookName = bookName;
            this.books = books;
        }
        private string? author;
        private string? bookName;
        private string[][][] books;

        public string getAuthor { get { return author!; } }
        public string getBookName { get { return bookName!; } }

        public string toString()
        {
            return $"{bookName} ushbu kitob {author} tomonidan yozilgan.";
        }

        public void add() { }
        public bool contains(string book, int floor, int closet)
        {
            for (var i = 0; i < books.Length; i++)
                if (books[floor][closet][i] == book) return true;
            return false;
        }
        public string getBooks(int floor, int closet)
        {
            string booksIntoShelf;
            for (var i = 0; i < books.Length; i++)
            {
                //booksIntoShelf += "Shelf";
            }
            return "";
            //return books[floor][closet][shelf]; 
        }
        public int getFloor() { return 1; }
        public int getShelf() { return 1; }
        public int getCloset() { return 1; }
        public void find() { }
    }*/

    #region other
    //public class Book
    //{

    //    private String author;
    //    private String title;
    //    private Shelve shelve;

    //    public Book(String author, String title)
    //    {
    //        this.author = author;
    //        this.title = title;
    //    }

    //    public String getAuthor()
    //    {
    //        return author;
    //    }

    //    public String getTitle()
    //    {
    //        return title;
    //    }

    //    public String toString()
    //    {
    //        return this.author + ", " + this.title;
    //    }

    //    public int getShelf()
    //    { // Javon nomeri
    //        return this.shelve.getNumber();
    //    }

    //    public String getCloset()
    //    { // Shkaf nomi
    //        return this.shelve.getCloset().getName();
    //    }

    //    public int getFloor()
    //    {
    //        return this.shelve.getCloset().getFloor().getNumber();
    //    }

    //    public void setShelve(Shelve shelve)
    //    {
    //        this.shelve = shelve;
    //    }

    //    public bool Equals(Object obj)
    //    {
    //        if (obj == null)
    //        {
    //            return false;
    //        }

    //        Book b = (Book)obj;

    //        if (this.author.Equals(b.author) && this.title.Equals(b.title))
    //        {
    //            return true;
    //        }
    //        return false;
    //    }


    //    public bool Equals(String author, String title)
    //    {
    //        if (this.author.Equals(author) && this.title.Equals(title))
    //        {
    //            return true;
    //        }
    //        return false;
    //    }
    //}


    //public class Shelve
    //{ // Javon

    //    Book[] kitoblar = new Book[10];
    //    int currentIndex = 0;

    //    private Closet closet;
    //    private int number;

    //    public Shelve(int number, Closet closet)
    //    {
    //        this.number = number;
    //        this.closet = closet;
    //    }

    //    public bool add(Book book)
    //    {
    //        if (this.currentIndex < 10)
    //        {
    //            kitoblar[this.currentIndex] = book;
    //            book.setShelve(this);
    //            this.currentIndex++;
    //            return true;
    //        }
    //        return false;
    //    }


    //    public bool bookContains(Book book)
    //    {
    //        for (int i = 0; i < this.kitoblar.Length; i++)
    //        {
    //            Book b = this.kitoblar[i];
    //            if (b != null)
    //            {
    //                if (b.Equals(book))
    //                {
    //                    return true;
    //                }
    //            }
    //        }
    //        return false;
    //    }


    //    public String getBooks()
    //    {
    //        String result = "";
    //        for (int i = 0; i < this.kitoblar.Length; i++)
    //        {
    //            Book book = this.kitoblar[i];
    //            if (book != null)
    //            {
    //                result += book.toString() + "\n";
    //            }
    //        }
    //        return result;
    //    }

    //    public int getNumber()
    //    {
    //        return number;
    //    }

    //    public Closet getCloset()
    //    {
    //        return closet;
    //    }

    //    public Book find(String author, String title)
    //    {
    //        for (int i = 0; i < this.kitoblar.Length; i++)
    //        {
    //            Book b = this.kitoblar[i];
    //            if (b != null && b.Equals(author, title))
    //            {
    //                return b;
    //            }
    //        }

    //        return null;
    //    }
    //}

    //public class Library
    //{

    //    Floor[] qavatlar = new Floor[3]; // qavat

    //    public Library()
    //    {
    //        for (int i = 0; i < 3; i++)
    //        {
    //            qavatlar[i] = new Floor(i);
    //        }
    //    }

    //    public bool add(Book book, int floor, String closet, int shelf)
    //    {
    //        Floor f = this.qavatlar[floor];
    //        return f.addBook(book, closet, shelf);
    //    }

    //    public bool contains(int floor, String closet, int shelf, Book book)
    //    {
    //        return this.qavatlar[floor].closetContains(closet, shelf, book);
    //    }

    //    public String getBooks(int floor, String closet)
    //    {
    //        return this.qavatlar[floor].getBooks(closet);
    //    }

    //    public Book find(String author, String title)
    //    {
    //        for (int i = 0; i < this.qavatlar.Length; i++)
    //        {
    //            Book b = this.qavatlar[i].find(author, title);
    //            if (b != null)
    //            {
    //                return b;
    //            }
    //        }
    //        return null;
    //    }
    //}

    //public class Floor
    //{ // qavat

    //    Closet[] shkaflar = new Closet[30];
    //    private int number;

    //    public Floor(int number)
    //    {
    //        this.number = number;
    //        for (int i = 0; i < 30; i++)
    //        {
    //            shkaflar[i] = new Closet("C" + (i + 1), this);
    //        }
    //    }


    //    public bool addBook(Book book, String closet, int shelf)
    //    {
    //        Closet cl = this.getCloset(closet);
    //        if (cl != null)
    //        {
    //            return cl.add(book, shelf);
    //        }
    //        return false;
    //    }


    //    public Closet getCloset(String closetName)
    //    {
    //        for (int i = 0; i < this.shkaflar.Length; i++)
    //        {
    //            if (closetName.Equals(this.shkaflar[i].getName()))
    //            {
    //                return this.shkaflar[i];
    //            }
    //        }
    //        return null;
    //    }

    //    public bool closetContains(String closet, int shelf, Book book)
    //    {
    //        Closet cl = this.getCloset(closet);
    //        if (cl != null)
    //        {
    //            return cl.shelfContains(shelf, book);
    //        }
    //        return false;
    //    }

    //    public String getBooks(String closet)
    //    {
    //        Closet cl = this.getCloset(closet);
    //        if (cl != null)
    //        {
    //            return cl.getBooks();
    //        }
    //        return " ";
    //    }

    //    public int getNumber()
    //    {
    //        return number;
    //    }

    //    public Book find(String author, String title)
    //    {
    //        for (int i = 0; i < this.shkaflar.Length; i++)
    //        {
    //            Book b = this.shkaflar[i].find(author, title);
    //            if (b != null)
    //            {
    //                return b;
    //            }
    //        }
    //        return null;
    //    }
    //}


    //public class Closet
    //{ // Shkaf
    //    private Shelve[] javonlar = new Shelve[6];
    //    private String name;
    //    private Floor floor;

    //    public Closet(String name, Floor floor)
    //    {
    //        this.name = name;
    //        this.floor = floor;
    //        for (int i = 0; i < 6; i++)
    //        {
    //            this.javonlar[i] = new Shelve(i, this);
    //        }
    //    }


    //    public String getName()
    //    {
    //        return name;
    //    }

    //    public bool add(Book book, int shelf)
    //    {
    //        return javonlar[shelf].add(book);
    //    }

    //    public bool shelfContains(int shelf, Book book)
    //    {
    //        return this.javonlar[shelf].bookContains(book);
    //    }

    //    public String getBooks()
    //    {
    //        String result = "";
    //        for (int i = 0; i < this.javonlar.Length; i++)
    //        {
    //            Shelve shelve = this.javonlar[i];
    //            result += "Shelf " + i + "\n";
    //            result += shelve.getBooks();
    //        }
    //        return result;
    //    }

    //    public Floor getFloor()
    //    {
    //        return floor;
    //    }

    //    public Book find(String author, String title)
    //    {
    //        for (int i = 0; i < this.javonlar.Length; i++)
    //        {
    //            Book b = this.javonlar[i].find(author, title);
    //            if (b != null)
    //            {
    //                return b;
    //            }
    //        }
    //        return null;
    //    }
    //}


    ///**
    // * OOP
    // * _Library_Application_
    // */
    //public class Main
    //{

    //    public static void main(String[] args)
    //    {
    //        // write your code here

    //        /** TEST  */
    //        Console.WriteLine("addBookTest() -> Library.addBook() : " + addBookTest());
    //        Console.WriteLine("containsTest() ->  Library.contains() : " + containsTest());
    //        Console.WriteLine("getBoinsTest() ->  Library.getBooks() : " + getBooksTest());
    //        Console.WriteLine("getBookPosition() ->  Book.(getCloset()/getCloset()/getShelf() : " + getBookPosition());
    //        Console.WriteLine("findTest() ->  Library.find() : " + findTest());

    //    }


    //    private static bool addBookTest()
    //    {
    //        // Kitob yaratish
    //        Book book1 = new Book("author 1", "title 1");
    //        Book book2 = new Book("author 2", "title 2");

    //        Library library = new Library();

    //        // Kitob qo'shish
    //        bool test1 = library.add(book1, 1, "C1", 1);
    //        if (!test1)
    //        {
    //            Console.WriteLine("addBookTest: test1 Hatolik");
    //            return false;
    //        }

    //        bool test2 = library.add(book2, 1, "C2", 1);

    //        if (!test2)
    //        {
    //            Console.WriteLine("addBookTest: test2 Hatolik");
    //            return false;
    //        }
    //        return true;
    //    }

    //    private static bool containsTest()
    //    {
    //        // Kitob yaratish
    //        Book book1 = new Book("author 1", "title 1");
    //        Book book2 = new Book("author 2", "title 2");

    //        Library library = new Library();

    //        // Kitob qo'shish
    //        library.add(book1, 1, "C1", 1);
    //        library.add(book2, 2, "C2", 1);

    //        // Kitob bor yo'qligini tekshirish
    //        bool test1 = library.contains(1, "C1", 1, book1);
    //        if (!test1)
    //        {
    //            Console.WriteLine("containsTest test1 Hatolik");
    //            return false;
    //        }

    //        bool test2 = library.contains(1, "C1", 1, new Book("a", "t"));
    //        if (test2)
    //        {
    //            Console.WriteLine("containsTest test2 Hatolik");
    //            return false;
    //        }

    //        bool test3 = library.contains(1, "C1", 1, new Book("author 1", "title 1"));
    //        if (!test3)
    //        {
    //            Console.WriteLine("containsTest test3 Hatolik");
    //            return false;
    //        }

    //        return true;
    //    }

    //    private static bool getBooksTest()
    //    {
    //        //Kitob yaratish
    //        Book book1 = new Book("author 1", "title 1");
    //        Book book2 = new Book("author 2", "title 2");

    //        Library library = new Library();

    //        // Kitob qo'shish
    //        library.add(book1, 1, "C1", 1);
    //        library.add(book2, 2, "C2", 1);

    //        String test1 = library.getBooks(1, "C1");
    //        if (!test1.contains("Shelf 0\n" +
    //                "Shelf 1\n" +
    //                "author 1, title 1\n" +
    //                "Shelf 2\n" +
    //                "Shelf 3\n" +
    //                "Shelf 4\n" +
    //                "Shelf 5\n"))
    //        {
    //            Console.WriteLine("getBooksTest test1 Hatolik");
    //            return false;
    //        }

    //        String test2 = library.getBooks(2, "C2");
    //        if (!test2.contains("Shelf 0\n" +
    //                "Shelf 1\n" +
    //                "author 2, title 2\n" +
    //                "Shelf 2\n" +
    //                "Shelf 3\n" +
    //                "Shelf 4\n" +
    //                "Shelf 5\n"))
    //        {
    //            Console.WriteLine("getBooksTest test2 Hatolik");
    //            return false;
    //        }
    //        return true;
    //    }

    //    private static bool getBookPosition()
    //    {
    //        //Kitob yaratish
    //        Book book1 = new Book("author 1", "title 1");
    //        Book book2 = new Book("author 2", "title 2");

    //        Library library = new Library();

    //        // Kitob qo'shish
    //        library.add(book1, 1, "C1", 1);
    //        library.add(book2, 2, "C2", 1);

    //        int test1 = book1.getFloor();
    //        if (test1 != 1)
    //        {
    //            Console.WriteLine("getBookPosition test1 ERROR");
    //            return false;
    //        }

    //        String test2 = book1.getCloset();
    //        if (!test2.Equals("C1"))
    //        {
    //            Console.WriteLine("getBookPosition test2 ERROR");
    //            return false;
    //        }

    //        int test3 = book1.getShelf();
    //        if (test3 != 1)
    //        {
    //            Console.WriteLine("getBookPosition test3 ERROR");
    //            return false;
    //        }

    //        int test4 = book2.getFloor();
    //        if (test4 != 2)
    //        {
    //            Console.WriteLine("getBookPosition test4 ERROR");
    //            return false;
    //        }

    //        String test5 = book2.getCloset();
    //        if (!test5.Equals("C2"))
    //        {
    //            Console.WriteLine("getBookPosition test5 ERROR");
    //            return false;
    //        }

    //        int test6 = book2.getShelf();
    //        if (test6 != 1)
    //        {
    //            Console.WriteLine("getBookPosition test6 ERROR");
    //            return false;
    //        }


    //        return true;
    //    }

    //    private static bool findTest()
    //    {
    //        // Kitob yaratish
    //        Book book1 = new Book("author 1", "title 1");
    //        Book book2 = new Book("author 2", "title 2");

    //        Library library = new Library();

    //        // Kitob qo'shish
    //        library.add(book1, 1, "C1", 1);
    //        library.add(book2, 2, "C2", 1);


    //        Book test1 = library.find("author 1", "title 1");
    //        if (test1 == null)
    //        {
    //            Console.WriteLine("findTest: test1 ERROR");
    //            return false;
    //        }

    //        Book test2 = library.find("author 2", "title 2");
    //        if (test2 == null)
    //        {
    //            Console.WriteLine("findTest: test2 ERROR");
    //            return false;
    //        }

    //        Book test3 = library.find("author 3", "title 3");
    //        if (test3 != null)
    //        {
    //            Console.WriteLine("findTest: test3 ERROR");
    //            return false;
    //        }


    //        return true;
    //    }
    //}
    #endregion

}
