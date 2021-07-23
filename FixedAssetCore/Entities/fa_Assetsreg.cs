using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FixedAssetCore.Core.Entities
{
    public class fa_Assetsreg
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string assetCode { get; set; }
        [StringLength(100)]
        public string assetDesc { get; set; }
        [StringLength(2)]
        public string Class { get; set;}
        [StringLength(15)]
        public string Dept { get; set; }
        [StringLength(2)]
        public string Busline { get; set; }
        [StringLength(8)]
        public string Purchdate { get; set; }

        [StringLength(8)]
        public string Revaldate { get; set; }

        [StringLength(8)]
        public string Reclassdate { get; set; }
        [StringLength(8)]
        public string movedate { get; set; }

        [StringLength(8)]
        public string Dispdate { get; set; }

        public Nullable<decimal> Purchval { get; set; }
        public Nullable<decimal> Accum_depre { get; set; }
        public Nullable<decimal> Dispval { get; set; }
        public Nullable<decimal> Revalval { get; set; }
        [StringLength(8)]
        public string Insurdate { get; set; }
        public Nullable<decimal> Insuredval { get; set; }
        public Nullable<decimal> year_depr { get; set; }
        public Nullable<decimal> depr_rate { get; set; }
    }
}
