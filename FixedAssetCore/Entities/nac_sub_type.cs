using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FixedAssetCore.Core.Entities
{
    public class nac_sub_type
    {
        [Key]
        public int Id { get; set; }
        public string subtype { get; set; }
        public string subtypedesc { get; set; }
    }
}
