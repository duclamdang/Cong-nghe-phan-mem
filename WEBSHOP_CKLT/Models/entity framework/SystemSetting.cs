using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WEBSHOP_CKLT.Models.entity_framework
{
    [Table("tb_SystemSetting")]
    public class SystemSetting
    {
        [Key]
 
        public string SettingKey { get; set; }  
        public string SettingValue { get; set; }
        public string SettingDescription { get; set; }
    }
}