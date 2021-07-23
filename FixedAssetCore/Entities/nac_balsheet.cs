using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FixedAssetCore.Core.Entities
{
    public class nac_balsheet
    {
        [Key]
        public int Id { get; set; }
        public string bl_code { get; set; }
        public string bl_desc { get; set; }
        public Nullable<System.DateTime> datecreated { get; set; }
        public string createdby { get; set; }
    }
}
