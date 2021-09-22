using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.EntityCoreVM
{
    public class fa_historyVM
    {
		public int Id { get; set; }
		public string assetCode { get; set; }
		public string assetdesc { get; set; }
		public string newclass { get; set; }
		public string oldclass { get; set; }
		public string newloc { get; set; }
		public string oldloc { get; set; }
		public string Busline { get; set; }
		public DateTime? Purchdate { get; set; }
		public DateTime? Revaldate { get; set; }
		public DateTime? Reclassdate { get; set; }
		public DateTime? movedate { get; set; }
		public DateTime? Dispdate { get; set; }
		public decimal? Purchval { get; set; }
		public decimal? Accum_depre { get; set; }
		public decimal? Dispval { get; set; }
		public decimal? newRevalval { get; set; }
		public decimal? oldrevalval { get; set; }
		public DateTime? insrenewdate { get; set; }
		public decimal? Insuredval { get; set; }
		public string userid { get; set; }
		public DateTime? lastopendate { get; set; }
		public string period { get; set; }
		public DateTime? oldrenewdate { get; set; }
	}
}
