using FixedAssetCore.Core.Entities;
using FixedAssetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.IRepositories
{
    public interface IAccountChart :IRepository<nac_chart>
    {
        Task<IEnumerable<ChartofAccountView>> getAllChartofAccountsCH();
        Task<List<ChartofAccountView>> GetChartofAccountByCode5(string maincode);
        Task<nac_chart> GetChartofAccountByCode(Expression<Func<nac_chart, bool>> predicate);
        Task<List<ChartofAccountView>> GetChartofAccountByCode2(string maincode);
        Task<List<ChartofAccountView>> GetChartofAccountByCode3(string maincode);
        Task<List<ChartofAccountView>> GetChartofAccountByCode4(string maincode);
        Task<List<ChartofAccountView>> GetChartofAccountByCode1(string maincode);
        Task<nac_chart> GetLasChartofAccountByCode(string maincode);
        nac_chart GetChartByDesc(string desc);
        Task<List<ChartofAccountView>> getAllChartofAccounts_Desc();
        Task<List<ChartofAccountView2>> getAllChartofAccounts_Desc2(int iDisplayStart, int iDisplayLength);
        Task<int> getChartofAccountListCount();
        Task<List<ChartofAccountView>> getListChartofAccounts_DescBymainAccount(string mainActCode);
        Task<ChartofAccountView> getSingleChartofAccounts_Desc(string mainActCode);

    }
}
