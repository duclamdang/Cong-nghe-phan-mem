using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBSHOP_CKLT.Models.entity_framework
{
    [Table("tb_ProductCategory")]
    public class ProductCategory : DungChung
    {
        public ProductCategory()
        {
            this.Product = new HashSet<Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [StringLength (150)]
        public string Title { get; set; }
        [Required]
        [StringLength(150)]
        public string Alias { get; set; }
        public string Description { get; set; }
        [StringLength(250)]
        public string Icon { get; set; }
        [StringLength(250)]
        public string SeoTitle { get; set; }
        [StringLength(500)]
        public string SeoDescription { get; set; }
        [StringLength(250)]
        public string SeoKeywords { get; set; }
        public ICollection<Product> Product { get; set; }

    }
}