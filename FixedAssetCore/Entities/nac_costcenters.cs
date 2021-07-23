using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FixedAssetCore.Core.Entities
{
    [NotMapped]
    public class nac_costcenters
    {
        [Key]
        public int Id { get; set; }

        [StringLength(5)]
        public string unitcode { get; set; }

        [StringLength(50)]
        public string unitdesc { get; set; }
    }
}
