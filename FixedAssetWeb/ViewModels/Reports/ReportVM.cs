using FixedAssetCore.Core.Entities;
using FixedAssetCore.EntityCoreVM;
using FixedAssetWeb.ViewModels.AssetMovementVM;
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
        public IEnumerable<DepreciationVM> DepreciationSummaryReport { get; set; }
        public IEnumerable<fa_historyVM> AssetNovementReport { get; set; }
        public IEnumerable<fa_AssetRegVM> InsuranceReport { get; set; }
        public IEnumerable<AssetDisposalVM> AssetDisposal { get; set; }
        public IEnumerable<DepreciationVM> MonthlyJournal { get; set; }
        public IEnumerable<DepreciationVM> MonthlyJournal2 { get; set; }

        public IEnumerable<DepreciationNoteVM> DepreciationNote { get; set; }
        public IEnumerable<DepreciationNoteVM> DepreciationNote2 { get; set; }
    }
}
