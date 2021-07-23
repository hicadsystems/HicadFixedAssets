using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FixedAssetCore.Entities
{
    public class fa_history
    {
		public int Id { get; set; }

		[StringLength(20)]
		public string assetCode { get; set; }

		[StringLength(50)]
		public string assetdesc { get; set; }

		[StringLength(2)]
		public string newclass { get; set; }

		[StringLength(2)]
		public string oldclass { get; set; }

		[StringLength(15)]
		public string newloc { get; set; }

		[StringLength(15)]
		public string oldloc { get; set; }

		[StringLength(2)]
		public string Busline { get; set; }

		public DateTime Purchdate { get; set; }
		public DateTime Revaldate { get; set; }
		public DateTime Reclassdate { get; set; }
		public DateTime movedate { get; set; }
		public DateTime Dispdate { get; set; }
		public decimal Purchval { get; set; }
		public decimal Accum_depre { get; set; }
		public decimal Dispval { get; set; }
		public decimal newRevalval { get; set; }
		public decimal oldrevalval { get; set; }
		public DateTime insrenewdate { get; set; }
		public decimal Insuredval { get; set; }

		[StringLength(15)]
		public string userid { get; set; }
		public DateTime lastopendate { get; set; }

		[StringLength(8)]
		public string period { get; set; }
		public DateTime oldrenewdate { get; set; }
	}
}
