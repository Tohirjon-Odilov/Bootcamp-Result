using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain.DTOs
{
    public class ResponceModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool isSuccess { get; set; }
    }
}
