﻿using FixedAssetCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.Models
{
    public class CostCenterView:nac_costcenters
    {
        public string companyname { get; set; }
        public string compaddress { get; set; }
    }
}
