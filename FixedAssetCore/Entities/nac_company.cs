using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FixedAssetCore.Core.Entities
{
	[NotMapped]
	public class nac_company
    { 
		[Key]
		public int Id { get; set; }
		public string comp_code { get; set; }
		public string comp_name { get; set; }
		public string Address { get; set; }
		public string Processyear { get; set; }
		public string processmonth { get; set; }
		public DateTime datecreated { get; set; }
		public string createdby { get; set; }
		public string salaryscale { get; set; }
		public string retireage { get; set; }
		public string hrlink { get; set; }
		public string town { get; set; }
		public string lg { get; set; }
		public string state { get; set; }
		public string email { get; set; }
		public string box { get; set; }
		public string tel { get; set; }
		public string serveraddr { get; set; }
		public string serverport { get; set; }
		public string email_pword { get; set; }
		public string mthly_tax { get; set; }
		public string runtype { get; set; }
	}
}
