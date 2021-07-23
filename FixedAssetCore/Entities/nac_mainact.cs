using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FixedAssetCore.Core.Entities
{
    public class nac_mainact
    {
        [Key]
        public int Id { get; set; }
        public string maincode { get; set; }
        public string description { get; set; }
        public string nac_balsheet_bl_code { get; set; }
        public string subtype { get; set; }
        public string shortname { get; set; }
        public Nullable<System.DateTime> datecreated { get; set; }
        public string createdby { get; set; }
    }
}
