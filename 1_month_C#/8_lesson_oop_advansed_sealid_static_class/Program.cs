using _8_lesson_oop_advansed_sealid_static_class.Shape;

var uchburchak = new Triangle(3, 4, 5, 9, 7);
Console.WriteLine(uchburchak.CalculateArea());
Console.WriteLine(uchburchak.CalculateArea());

var tortburchak = new Rectengular(2, 2, 2, 2);
Console.WriteLine(tortburchak.CalculatePerimeter());
Console.WriteLine(tortburchak.CalculateArea());

var dumaloq = new Circle(8, 4, 5);
Console.WriteLine(dumaloq.CalculatePerimeter());
Console.WriteLine(dumaloq.CalculateArea());

//////////////////////////// Library ////////////////////////////////


#region Library
static void Main(string[] args)
{
    Author author1 = new Author("Author1");
    Author author2 = new Author("Author2");

    Book book1 = new Book(author1, "Title1");
    Book book2 = new Book(author2, "Title2");

    Library library = new Library();

    library.AddBook(book1, 1, 1, 1, 1);
    library.AddBook(book2, 2, 2, 2, 2);

    Console.WriteLine(library.GetBooks());

    Console.WriteLine("Floor: " + library.GetFloor(book1));
    Console.WriteLine("Closet: " + library.GetCloset(book1));
    Console.WriteLine("Shelf: " + library.GetShelf(book1));

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
    Book foundBook = library.FindBook("Author2", "Title2");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
    if (foundBook != null)
    {
        Console.WriteLine("Found book: " + foundBook.ToString());
    }
    else
    {
        Console.WriteLine("Book not found.");
    }
    #endregion
}