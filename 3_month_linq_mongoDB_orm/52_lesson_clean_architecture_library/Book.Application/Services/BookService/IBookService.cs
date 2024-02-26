using Book.Domain.Entities.DTOs;
using Book.Domain.Entities.Models;

namespace Book.Application.Services.BookService
{
    public interface IBookService
    {
        public Task<string> CreateBookAsync(UserProfileDTO userDTO, string picturePath);
        public Task<List<UserProfile>> GetAllBookAsync();
        public Task<UserProfile> GetByIdBookAsync(int id);
        public Task<bool> DeleteBookAsync(int id);
        public Task<UserProfile> UpdateBookAsync(int id, UserProfileDTO modelDTO);
    }
}
