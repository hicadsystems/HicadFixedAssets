using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.ViewModels.AssetMovementVM
{
    public class fa_AssetRegVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string assetCode { get; set; }
        [StringLength(100)]
        public string assetDesc { get; set; }
        [StringLength(2)]
        public string classCode { get; set; }
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

        public decimal? Purchval { get; set; }
        public decimal? Accum_depre { get; set; }
        public decimal? Dispval { get; set; }
        public decimal? Revalval { get; set; }
        [StringLength(8)]
        public string Insurdate { get; set; }
        public decimal? Insuredval { get; set; }
        public decimal? year_depr { get; set; }
        public decimal? depr_rate { get; set; }
    }
}
