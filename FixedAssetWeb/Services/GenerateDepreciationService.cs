﻿using FixedAssetCore.Core.Data;
using FixedAssetWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Services
{
    public class GenerateDepreciationService : IGenerateDepreciationService
    {
        private IUnitOfWork unitOfWork;
        public GenerateDepreciationService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public string GenerateDepreciation(DateTime dateTime)
        {
            string responseMessage = unitOfWork.reg.GenerateAssetsDepreciation(dateTime);

            return responseMessage;
        }
    }
}