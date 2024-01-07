using System.Text;

namespace _8_lesson_oop_advansed_sealid_static_class
{
    internal class Shelf
    {
        private int Floor { get; }
        private int Closet { get; }
        private Book[,,] Books { get; }

        public Shelf(int floor, int closet)
        {
            Floor = floor;
            Closet = closet;
            Books = new Book[floor, closet, 6];
        }

        public void Add(Book book, int floor, int closet, int javon)
        {
            if (Books[floor, closet, javon] == null)
            {
                Books[floor, closet, javon] = book;
            }
        }

        public bool Contains(Book book, int floor, int closet, int javon)
        {
            return book.Equals(Books[floor, closet, javon]);
        }

        public string GetBooks()
        {
            StringBuilder result = new StringBuilder();
            for (int f = 0; f < Floor; f++)
            {
                result.AppendLine($"Shelf {f + 1}");
                for (int c = 0; c < Closet; c++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (Books[f, c, j] != null)
                        {
                            result.AppendLine(Books[f, c, j].ToString());
                        }
                    }
                }
            }
            return result.ToString();
        }

        public int GetFloor(Book book)
        {
            for (int f = 0; f < Floor; f++)
            {
                for (int c = 0; c < Closet; c++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (book.Equals(Books[f, c, j]))
                        {
                            return f + 1;
                        }
                    }
                }
            }
            return -1;
        }

        public int GetCloset(Book book)
        {
            for (int f = 0; f < Floor; f++)
            {
                for (int c = 0; c < Closet; c++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (book.Equals(Books[f, c, j]))
                        {
                            return c + 1;
                        }
                    }
                }
            }
            return -1;
        }

        public int GetShelf(Book book)
        {
            for (int f = 0; f < Floor; f++)
            {
                for (int c = 0; c < Closet; c++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (book.Equals(Books[f, c, j]))
                        {
                            return j + 1;
                        }
                    }
                }
            }
            return -1;
        }

        public Book? Find(string authorName, string title)
        {
            for (int f = 0; f < Floor; f++)
            {
                for (int c = 0; c < Closet; c++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (Books[f, c, j] != null && Books[f, c, j].Author.Name.Equals(authorName)
                            && Books[f, c, j].Title.Equals(title))
                        {
                            return Books[f, c, j];
                        }
                    }
                }
            }
            return null;
        }
    }
}
