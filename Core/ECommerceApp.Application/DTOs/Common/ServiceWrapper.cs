using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.DTOs.Common
{
    public class ServiceWrapper<T> : BaseResponse where T : class, new()
    {
        public T Result { get; set; } = new T();

        public ServiceWrapper(T result)
        {
            Result = result ?? throw new ArgumentNullException(nameof(result));
        }
    }
}
