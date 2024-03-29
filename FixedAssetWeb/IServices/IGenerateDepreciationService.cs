﻿using FixedAssetCore.EntityCoreVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IGenerateDepreciationService
    {
        string GenerateDepreciation(string username, DateTime dateTime);
        IEnumerable<DepreciationVM> SortAssetsDeprecation(SortAssetsRegListVM sortAssetsRegListVM);
        IEnumerable<DepreciationVM> DeprecationSummaryReport(string assetCode);
        string UpdateDepreciations(string month, string year);
        IEnumerable<DepreciationVM> SortDepreciationsByClass(string month, string year);
        IEnumerable<DepreciationVM> OrderDepreciationsByClass(string month, string year);
        IEnumerable<DepreciationNoteVM> DepreciationNoteService(string classCode, string month, string year);
        IEnumerable<DepreciationVM> DepreciationScheduleByClass(string classCode);
        IEnumerable<DepreciationVM> GroupDepreciationScheduleByClass(string classCode);
        IEnumerable<DepreciationVM> DepreciationScheduleByDept(string dept);

        IEnumerable<DepreciationVM> GroupDepreciationScheduleByDept(string dept);
        IEnumerable<DepreciationVM> DepreciationScheduleByBusinessLine(string busline);

        IEnumerable<DepreciationVM> GroupDepreciationScheduleByBusinessLine(string busline);
        IEnumerable<DepreciationNoteVM> GetDepreciationNoteByClassService(string classCode, string month, string year);
    }
}
