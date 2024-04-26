using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEBSHOP_CKLT.Models.entity_framework
{
    [Table("tb_OrderDetail")]

    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int OrderID { get; set; }
     
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}