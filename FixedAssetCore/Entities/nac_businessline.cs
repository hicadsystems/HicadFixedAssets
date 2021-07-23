using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FixedAssetCore.Core.Entities
{
    [NotMapped]
    public class nac_businessline
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> startDate { get; set; }
        public int processingYear { get; set; }
        public int processingMonth { get; set; }
        public string interestacct { get; set; }
        public string incomeacct { get; set; }
        public string fundacct { get; set; }
        public int receiptno { get; set; }
        public int paymentno { get; set; }
        public int jvno { get; set; }
        public string trusteeacct { get; set; }
        public string profitacct { get; set; }
        public string createdby { get; set; }
        public Nullable<System.DateTime> datecreated { get; set; }
    }
}
