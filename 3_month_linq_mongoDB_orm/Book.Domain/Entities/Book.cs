using Book.Domain.Common;
using Book.Domain.Enums;

namespace Book.Domain.Entities
{
    public class LibraryBook : BaseEntity
    {
        public LibraryBook()
        {
            Name = string.Empty;
            Description = string.Empty;
            Author = string.Empty;
        }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Author { get; set; }
        public required int Price { get; set; }
        public required Ganre Ganre { get; set; }
    }
}
