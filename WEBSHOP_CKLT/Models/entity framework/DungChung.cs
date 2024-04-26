using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBSHOP_CKLT.Models.entity_framework
{
    public abstract class DungChung
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set;}
        public DateTime ModiferDate { get; set;}
        public string ModifierBy { get; set; }
        public int Position { get; set; }
    }
   
}