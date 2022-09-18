using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.DTOs.Common
{
    public class BaseResponse
    {
        public Guid RequestId { get; set; } = Guid.NewGuid();
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;

    }
}
