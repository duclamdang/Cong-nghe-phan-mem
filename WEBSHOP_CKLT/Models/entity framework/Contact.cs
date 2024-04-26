using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEBSHOP_CKLT.Models.entity_framework
{
    [Table("tb_Contact")]
    public class Contact : DungChung
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsRead  { get; set; }
    }
}