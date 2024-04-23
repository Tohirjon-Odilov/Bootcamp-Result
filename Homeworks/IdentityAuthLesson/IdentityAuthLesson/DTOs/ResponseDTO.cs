using Microsoft.AspNetCore.Server.HttpSys;

namespace IdentityAuthLesson.DTOs
{
    public class ResponseDTO
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; } = false;
    }
}
