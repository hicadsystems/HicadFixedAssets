using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FixedAssetCore.Entities
{
    public class fa_gdepreciation
    {
        public int Id { get; set; }

		[Required]
		[StringLength(20)]
        public string assetcode { get; set; }

		[Required]
		[StringLength(4)]
		public string assetyear { get; set; }

		[Required]
		[StringLength(2)]
		public string assetmonth { get; set; }

		[StringLength(6)]
		public string period { get; set; }

		[StringLength(100)]
		public string assetdesc { get; set; }
		public decimal? purchval { get; set; }
		public DateTime? purchdate { get; set; }
		public decimal? newclassval { get; set; }
		public decimal? oldclassval { get; set; }
		public decimal? newdeptval { get; set; }
		public decimal? olddeptval { get; set; }
		public decimal? accum_depr { get; set; }
		public DateTime? calc_date { get; set; }

		[StringLength(20)]
		public string userid { get; set; }

		[StringLength(50)]
		public string oldloc { get; set; }

		[StringLength(50)]
		public string newloc { get; set; }

		[StringLength(50)]
		public string oldclass { get; set; }

		[StringLength(50)]
		public string newclass { get; set; }
		public decimal? bookval { get; set; }
		public Single? depreciation { get; set; }

		[StringLength(15)]
		public string cost_acctcode { get; set; }

		[StringLength(15)]
		public string depr_acctcode { get; set; }

		[StringLength(15)]
		public string exps_acctcode { get; set; }

		[StringLength(20)]
		public string busdesc { get; set; }

		[StringLength(20)]
		public string mondesc { get; set; }

		[StringLength(20)]
		public string busline { get; set; }
		public string loc { get; set; }
	}
}
