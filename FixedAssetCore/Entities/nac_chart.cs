using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FixedAssetCore.Core.Entities
{
    public class nac_chart
    {
        [Key]
        public int Id { get; set; }
        public string acctcode { get; set; }
        public string description { get; set; }
        public string mainAccountCode { get; set; }
        public string subtype { get; set; }
        public bool ispersonel { get; set; }
        public string Email { get; set; }
        public string balSheetCode { get; set; }
        public Nullable<System.DateTime> datecreated { get; set; }
        public string createdby { get; set; }
    }
}
