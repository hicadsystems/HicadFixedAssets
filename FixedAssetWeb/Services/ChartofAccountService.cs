using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Models;
using FixedAssetWeb.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Services
{
    public class ChartofAccountService :IChartofAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        public ChartofAccountService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;

        }

        public Task<nac_chart> GetChartofAccountByCode(string actcode)
        {
            return unitOfWork.accountChart.GetChartofAccountByCode(x => x.acctcode == actcode);

        }
        public Task<IEnumerable<ChartofAccountView>> getAllChartofAccountsCH()
        {
            return unitOfWork.accountChart.getAllChartofAccountsCH();

        }
        public Task<List<ChartofAccountView>> GetChartofAccountByCode1(string actcode)
        {
            return unitOfWork.accountChart.GetChartofAccountByCode1(actcode);

        }
        public Task<List<ChartofAccountView>> GetChartofAccountByCode2(string actcode)
        {
            return unitOfWork.accountChart.GetChartofAccountByCode2(actcode);

        }
        public Task<List<ChartofAccountView>> GetChartofAccountByCode3(string actcode)
        {
            return unitOfWork.accountChart.GetChartofAccountByCode3(actcode);

        }
        public Task<List<ChartofAccountView>> GetChartofAccountByCode4(string actcode)
        {
            return unitOfWork.accountChart.GetChartofAccountByCode4(actcode);

        }
        public Task<List<ChartofAccountView>> GetChartofAccountByCode5(string actcode)
        {
            return unitOfWork.accountChart.GetChartofAccountByCode5(actcode);

        }

        public Task<nac_chart> GetLastChartofAccountByCode(string actcode)
        {
            return unitOfWork.accountChart.GetLasChartofAccountByCode(actcode);

        }
        public async Task<bool> AddChartofAccount(nac_chart nac_chart)
        {
            unitOfWork.accountChart.Create(nac_chart);
            return await unitOfWork.Done();
        }

        public IEnumerable<nac_chart> GetChartofAccounts()
        {
            return unitOfWork.accountChart.All();
        }

        public Task<List<ChartofAccountView>> getChartofAccountAndDesc()
        {
            return unitOfWork.accountChart.getAllChartofAccounts_Desc();
        }

        public Task<List<ChartofAccountView>> getListChartofAccounts_DescBymainAccount(string mainActCode)
        {
            return unitOfWork.accountChart.getListChartofAccounts_DescBymainAccount(mainActCode);
        }

        public Task<ChartofAccountView> getSingleChartofAccounts_Desc(string actCode)
        {
            return unitOfWork.accountChart.getSingleChartofAccounts_Desc(actCode);
        }


        public Task<nac_chart> GetChartofAccountById(int id)
        {
            return unitOfWork.accountChart.Find(id);
        }

        public async Task<bool> UpdateChartofAccount(nac_chart nac_chart)
        {
            unitOfWork.accountChart.Update(nac_chart);
            return await unitOfWork.Done();
        }

        public void RemoveChart(nac_chart nac_chart)
        {
            unitOfWork.accountChart.Remove(nac_chart);
            unitOfWork.Done();
        }
        public async Task<List<ChartofAccountView2>> getChartofAccountAndDesc2(int iDisplayStart, int iDisplayLength)
        {
            return await unitOfWork.accountChart.getAllChartofAccounts_Desc2(iDisplayStart, iDisplayLength);
        }
        public async Task<int> getChartofAccountCount()
        {
            return await unitOfWork.accountChart.getChartofAccountListCount();
        }

        public nac_chart GetChartByDesc(string desc)
        {
            return unitOfWork.accountChart.GetChartByDesc(desc);
        }
    }
}
