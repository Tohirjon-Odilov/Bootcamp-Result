using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sign_Identity.Domain.DTOs
{
    public class AuthDTO
    {
        public string? Token {  get; set; }
        public bool IsSuccess { get; set; } = false;
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
