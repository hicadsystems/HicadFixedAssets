using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FixedAssetCore.Core.Entities
{
    public class fa_class
    {
        public int Id { get; set; }

        [StringLength(2)]
        public string classcode { get; set; }
        [StringLength(60)]
        public string classdesc { get; set; }
        public decimal Deprrate { get; set; }
        [StringLength(1)]
        public string Deprmethod { get; set; }
        [StringLength(15)]
        public string Led_cost_code { get; set; }

        [StringLength(15)]
        public string Led_accum_depr_code { get; set; }

        [StringLength(15)]
        public string Led_exp_code { get; set; }

        [StringLength(1)]
        public string rank { get; set; }
        
    }
}
