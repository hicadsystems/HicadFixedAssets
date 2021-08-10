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
        public string newClassCode { get; set; }

        [StringLength(2)]
        public string oldClassCode { get; set; }
        [StringLength(15)]
        public string Dept { get; set; }
        [StringLength(2)]
        public string Busline { get; set; }
        [StringLength(8)]
        public string Purchdate { get; set; }

        public DateTime? Revaldate { get; set; }

        public DateTime? Reclassdate { get; set; }
        public DateTime? movedate { get; set; }

        public DateTime? Dispdate { get; set; }

        [StringLength(15)]
        public string oldLoc { get; set; }

        [StringLength(15)]
        public string newLoc { get; set; }

        [StringLength(15)]
        public string userId { get; set; }

        public decimal? Purchval { get; set; }
        public decimal? Accum_depre { get; set; }
        public decimal? Dispval { get; set; }
        public decimal? Revalval { get; set; }
        public decimal? newRevalval { get; set; }
        public decimal? oldRevalval { get; set; }

        public DateTime? Insurdate { get; set; }
        public DateTime? Insurnewdate { get; set; }

        public DateTime? lastOpenDate { get; set; }
        public decimal? Insuredval { get; set; }
        public decimal? year_depr { get; set; }
        public decimal? depr_rate { get; set; }

        [StringLength(8)]
        public string Period { get; set; }

        public DateTime? oldrenewdate { get; set; }

        [StringLength(15)]
        public string newUnitCode { get; set; }

        [StringLength(15)]
        public string oldUnitCode { get; set; }

        [StringLength(100)]
        public string unitCodeDescription { get; set; }
    }
}
