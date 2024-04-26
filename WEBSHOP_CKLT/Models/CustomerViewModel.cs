using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBSHOP_CKLT.Models
{
    public class CustomerViewModel
    {
        public string CustomernName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Payment { get; set; }

    }
}