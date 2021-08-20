using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.EntityCoreVM
{
    public class AssetRegListVM
    {
        public int Id { get; set; }
        public string assetCode { get; set; }

        public string assetDesc { get; set; }

        public string classCode { get; set; }

        public string classDesc { get; set; }

        public string unitCode { get; set; }

        public string unitDesc { get; set; }

        public string busline { get; set; }

        public string buslineDesc { get; set; }

        public decimal? purchval { get; set; }
    }
}
