using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.DTO
{
    public class ResponseModel
    {
        public bool IsSuccess {  get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
