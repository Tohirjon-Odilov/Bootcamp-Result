﻿namespace _8_lesson_oop_advansed_sealid_static_class
{
    public class Library
    {
        
        public Library(string author, string bookName, string[] books) 
        {
            this.author = author;
            this.bookName = bookName;
            this.books = books;
        }
        private string? author;
        private string? bookName;
        private string[] books;

        public string getAuthor{ get { return author!; } }
        public string getBookName { get { return bookName!; } }

        public string toString()
        {
            return $"{bookName} ushbu kitob {author} tomonidan yozilgan.";
        }

        public void add() { }
        public void contains(int floor, int shelf) { }
        public string getBooks() { return $"Shelf {1}, "; }
        public int getFloor() { return 1; }
        public int getShelf() {  return 1; }
        public int getCloset() { return 1; }
        public void find() { }
    }
}
