using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.EntityCoreVM
{
    public class DepreciationVM
    {
			public int Id { get; set; }
			public string assetcode { get; set; }
			public string assetyear { get; set; }
			public string assetmonth { get; set; }
			public string period { get; set; }
			public string assetdesc { get; set; }
			public decimal? purchval { get; set; }
			public DateTime? purchdate { get; set; }
			public decimal? newclassval { get; set; }
			public decimal? oldclassval { get; set; }
			public decimal? newdeptval { get; set; }
			public decimal? olddeptval { get; set; }
			public decimal? accum_depr { get; set; }
			public DateTime? calc_date { get; set; }
			public string userid { get; set; }
			public string oldloc { get; set; }
			public string newloc { get; set; }
			public string oldclass { get; set; }
			public string newclass { get; set; }
			public decimal? bookval { get; set; }
			public Single? depreciation { get; set; }
			public string cost_acctcode { get; set; }
			public string depr_acctcode { get; set; }
			public string exps_acctcode { get; set; }
			public string busdesc { get; set; }
			public string mondesc { get; set; }
			public string busline { get; set; }
			public string loc { get; set; }
	}

}
