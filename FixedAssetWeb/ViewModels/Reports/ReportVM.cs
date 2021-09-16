using FixedAssetCore.Core.Entities;
using FixedAssetCore.EntityCoreVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.ViewModels.Reports
{
    public class ReportVM
    {
        public IEnumerable<nac_businessline> BusinesslinesReport { get; set; }
        public nac_company Company { get; set; }
        public IEnumerable<nac_costcenters> CostcenterReport { get; set; }
        public IEnumerable<fa_class> AssetclassReport { get; set; }
        public IEnumerable<AssetRegListVM> GetAssetRegReport { get; set; }
        public IEnumerable<AssetRegListVM> AssetRegListReport { get; set; }
        public IEnumerable<DepreciationVM> DepreciationValueReport { get; set; }
    }
}
