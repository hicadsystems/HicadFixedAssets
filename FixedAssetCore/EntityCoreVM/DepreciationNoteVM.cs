using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.EntityCoreVM
{
    public  class DepreciationNoteVM
    {
        public string Class { get; set; }
        public decimal? Cost { get; set; }
        public string CostStartDate { get; set; }
        public decimal? Additions { get; set; }
        public decimal? Reclassifications { get; set; }
        public decimal? Disposal { get; set; }
        public string CostEndDate { get; set; }
        public float? Depreciation { get; set; }
        public string DepreciationStartDate { get; set; }
        public decimal? ChargeForTheYear { get; set; }
        public decimal? DeprReclassifications { get; set; }
        public decimal? DeprDisposal { get; set; }
        public string DepreciationEndDate { get; set; }
        public decimal? NetBook { get; set; }
        public string NetBookStartDate { get; set; }
        public string NetBookEndDate { get; set; }
    }
}
