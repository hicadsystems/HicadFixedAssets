using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.EntityCoreVM
{
    public class AssetDisposalVM
    {
        public string assetCode { get; set; }
        public string assetDesc { get; set; }
        public string Dept { get; set; }
        public DateTime? Dispdate { get; set; }
        public decimal? Dispval { get; set; }
    }
}
