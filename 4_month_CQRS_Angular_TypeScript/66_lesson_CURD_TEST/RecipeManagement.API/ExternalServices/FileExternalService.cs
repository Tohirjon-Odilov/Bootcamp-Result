namespace RecipeManagement.API.ExternalServices
{
    public class FileExternalService
    {
        private readonly IWebHostEnvironment _env;

        public FileExternalService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> AddFileAndGetPath(IFormFile file)
        {
            string path = Path.Combine(_env.WebRootPath, "RecipeInstructions", Guid.NewGuid() + file.FileName);

            using (var stream = File.Create(path))
            {
                await file.CopyToAsync(stream);
            }

            return path;
        }
    }
}
