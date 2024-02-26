using Book.Application.Services.BookService;
using Book.Application.Services.LibraryService;
using Microsoft.Extensions.DependencyInjection;

namespace FileAPILesson.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILibraryService, LibraryService>();
            return services;
        }
    }
}