using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FixedAssetCore.Entities
{
    public class ac_month
    {
        public int Id { get; set; }

        [StringLength(2)]
        public string cmonth { get; set; }

        [StringLength(12)]
        public string mthdesc { get; set; }
    }
}
