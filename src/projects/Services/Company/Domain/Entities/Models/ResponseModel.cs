using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class ResponseModel<T>
    {
        public string Status { get; set; }
        public T Data { get; set; }
    }
}
