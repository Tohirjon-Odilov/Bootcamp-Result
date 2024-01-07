namespace _8_lesson_oop_advansed_sealid_static_class
{
    internal class Book
    {
        public Author Author { get; }
        public string Title { get; }

        public Book(Author author, string title)
        {
            Author = author;
            Title = title;
        }

        public override string ToString()
        {
            return $"{Author.Name}, {Title}";
        }
    }
}
