using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEBSHOP_CKLT.Models.entity_framework
{
    [Table("tb_Ads")]
    public class Ads : DungChung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Type { get; set; }
        public string Link { get; set; }
      

    }
}