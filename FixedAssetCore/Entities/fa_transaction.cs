using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FixedAssetCore.Entities
{
	public class fa_transaction
	{
		public int Id { get; set; }

		[StringLength(20)]
		public string assetCode { get; set; }

		[StringLength(50)]
		public string assetdesc { get; set; }

		[StringLength(2)]
		public string Class{ get; set; }

		[StringLength(15)]
		public string Dept { get; set; }

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
		public decimal Revalval { get; set; }
		public DateTime Insurdate { get; set; }
		public decimal Insuredval { get; set; }
	}

}
