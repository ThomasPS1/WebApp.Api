using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApp.Entity.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string? ProductName { get; set; }
        public  int Qty { get; set; }
        public int UnitPrice { get; set; }
        public int TotalPrice { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("customerId")]
        public Customer? Customer { get; set; }

    }
}
