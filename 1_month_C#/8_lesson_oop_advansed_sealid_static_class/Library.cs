namespace _8_lesson_oop_advansed_sealid_static_class
{
    public class Library
    {
        
        public Library(string author, string bookName, string[][][] books) 
        {
            this.author = author;
            this.bookName = bookName;
            this.books = books;
        }
        private string? author;
        private string? bookName;
        private string[][][] books;

        public string getAuthor{ get { return author!; } }
        public string getBookName { get { return bookName!; } }

        public string toString()
        {
            return $"{bookName} ushbu kitob {author} tomonidan yozilgan.";
        }

        public void add() { }
        public bool contains(string book, int floor, int closet) { 
            for(var i = 0;  i < books.Length; i++)
                if (books[floor][closet][i] == book) return true;
            return false;
        }
        public string getBooks(int floor, int closet) 
        {
            string booksIntoShelf;
            for(var i = 0; i < books.Length; i++)
            {
                //booksIntoShelf += "Shelf";
            }
            return;
            //return books[floor][closet][shelf]; 
        }
        public int getFloor() { return 1; }
        public int getShelf() {  return 1; }
        public int getCloset() { return 1; }
        public void find() { }
    }
}
