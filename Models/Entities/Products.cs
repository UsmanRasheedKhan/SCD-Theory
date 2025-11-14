using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace technova_ecom.Models.Entities
{
    [Table("Products")]
    public class Products
    {
        [Column("product_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Column("product_name")]
        public string ProductName { get; set; }

        [Column("price")]
        public decimal price { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("quantiy")]
        public int Quantity { get; set; }

        [Column("ratings")]
        public decimal Rating { get; set; }
    }
}
