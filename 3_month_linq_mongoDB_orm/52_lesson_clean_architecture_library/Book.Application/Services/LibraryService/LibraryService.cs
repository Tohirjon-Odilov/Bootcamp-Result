using Book.Application.Abstractions.Repositories;
using Book.Application.DataTransferObjects;
using Book.Domain.Entities;

namespace Book.Application.Services.Library
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _LibraryRepository;

        public LibraryService(ILibraryRepository LibraryRepository)
            => _LibraryRepository = LibraryRepository;

        public async Task<Library> InsertAsync(LibraryDTO LibraryDTO)
        {
            var Library = new Library()
            {
                Name = LibraryDTO.Name
            };

            Library = await _LibraryRepository.InsertAsync(Library);

            return Library;
        }

        public async Task<List<Library>> SelectAllAsync()
            => await _LibraryRepository.SelectAllAsync();

        public async Task<Library> SelectByIdAsync(long id)
            => await _LibraryRepository.SelectByIdAsync(id);

        public async Task<Library> UpdateAsync(LibraryDTO LibraryDTO, long id)
        {
            var Library = new Library()
            {
                Name = LibraryDTO.Name
            };

            var gerne = await _LibraryRepository.UpdateAsync(Library, id);

            return Library;
        }

        public async Task<Library> DeleteAsync(long id)
        {
            var Library = await _LibraryRepository.DeleteAsync(id);

            return Library;
        }
    }
}
