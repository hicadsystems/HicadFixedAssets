using FixedAssetCore.Core.Entities;
using FixedAssetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IChartofAccountService
    {
        Task<IEnumerable<ChartofAccountView>> getAllChartofAccountsCH();
        IEnumerable<nac_chart> GetChartofAccounts();
        Task<nac_chart> GetChartofAccountById(int id);
        Task<nac_chart> GetChartofAccountByCode(string bcode);
        Task<List<ChartofAccountView>> GetChartofAccountByCode1(string bcode);
        Task<List<ChartofAccountView>> GetChartofAccountByCode2(string bcode);
        Task<List<ChartofAccountView>> GetChartofAccountByCode3(string bcode);
        Task<List<ChartofAccountView>> GetChartofAccountByCode4(string bcode);
        Task<List<ChartofAccountView>> GetChartofAccountByCode5(string bcode);
        Task<List<ChartofAccountView2>> getChartofAccountAndDesc2(int iDisplayStart, int iDisplayLength);
        Task<int> getChartofAccountCount();
        Task<List<ChartofAccountView>> getChartofAccountAndDesc();
        Task<nac_chart> GetLastChartofAccountByCode(string bcode);
        Task<List<ChartofAccountView>> getListChartofAccounts_DescBymainAccount(string mainActCode);
        Task<ChartofAccountView> getSingleChartofAccounts_Desc(string actCode);
        Task<bool> AddChartofAccount(nac_chart nac_Chart);
        Task<bool> UpdateChartofAccount(nac_chart nac_Chart);
        nac_chart GetChartByDesc(string desc);
        void RemoveChart(nac_chart nac_Chart);
    }
}
