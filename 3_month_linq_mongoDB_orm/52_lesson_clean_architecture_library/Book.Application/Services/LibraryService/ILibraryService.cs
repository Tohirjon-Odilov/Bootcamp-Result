using Book.Domain.Entities.DTOs;
using Book.Domain.Entities.Models;

namespace Book.Application.Services.LibraryService
{
    public interface ILibraryService
    {
        public Task<string> CreateLibraryAsync(UserProfileDTO userDTO, string picturePath);
        public Task<List<UserProfile>> GetAllLibraryAsync();
        public Task<UserProfile> GetByIdLibraryAsync(int id);
        public Task<bool> DeleteLibraryAsync(int id);
        public Task<UserProfile> UpdateLibraryAsync(int id, UserProfileDTO modelDTO);
    }
}
