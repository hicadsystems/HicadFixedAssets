﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IGenerateDepreciationService
    {
        string GenerateDepreciation(DateTime dateTime);
    }
}