using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEBSHOP_CKLT.Models.entity_framework
{
    [Table("tb_Category")]
    public class Category : DungChung
    {
        public Category()
        {
            this.News = new HashSet<News>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required(ErrorMessage ="Tên danh mục không được để trống")]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        [StringLength(150)]
        public string SeoTitle { get; set; }
        [StringLength(250)]
        public string SeoDescription { get; set; }
        [StringLength(150)]
        public string SeoKeywords { get; set; }

        public bool IsActived { get; set; }

        public ICollection<News> News { get; set; }
        public ICollection<Post> Post { get; set; }
    }
}