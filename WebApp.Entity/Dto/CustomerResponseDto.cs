using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Entity.Dto
{
    public class CustomerResponseDto
    {
        public int CustomerId { get; set; }
        public string customName { get; set; }
        public string ProductName { get; set; }
        public int OrderId { get; set; }
        public int Qty { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }

    }
}
