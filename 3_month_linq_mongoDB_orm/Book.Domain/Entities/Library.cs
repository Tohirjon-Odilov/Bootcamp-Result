using Book.Domain.Common;

namespace Book.Domain.Entities
{
    public class Library : BaseEntity
    {
        public Library()
        {
            Name = string.Empty;
            Description = string.Empty;
            Librarier = string.Empty;
            Address = string.Empty;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Librarier { get; set; }
        public string Address { get; set; }
    }
}
