using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace technova_ecom.Models.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Column("category_id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Column("category_name")]
        public string CategoryName { get; set; }

        [Column("display_order")]
        public int Display_order { get; set; }

        //CATEGORY HAS MANY PRODUCTS 
        public ICollection<Products> Products { get; set; } 
    }
}
