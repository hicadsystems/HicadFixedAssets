using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using FixedAssetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Core.Repositories
{
    public class ChartRepository : Repository<nac_chart>, IAccountChart
    {
        private readonly IAssetDbContext context;
        public ChartRepository(IAssetDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<ChartofAccountView>> getAllChartofAccountsCH()
        {
            string companyname = context.nac_company.FirstOrDefault().comp_name;
            string address = context.nac_company.FirstOrDefault().Address;

            return await (from npfCharts in context.nac_charts
                          join npfmain in context.nac_mainacts on npfCharts.mainAccountCode equals npfmain.maincode
                          join npfbal in context.nac_balsheets on npfCharts.balSheetCode equals npfbal.bl_code
                          join npfsubtype in context.nac_sub_Types on npfCharts.subtype equals npfsubtype.subtype
                          where npfCharts.subtype != "0" && npfCharts.balSheetCode != "0"
                          orderby npfCharts.acctcode
                          select new ChartofAccountView
                          {
                              Id = npfCharts.Id,
                              acctcode = npfCharts.acctcode,
                              description = npfCharts.description,
                              mainAccountCode = npfCharts.mainAccountCode,
                              subtype = npfCharts.subtype,
                              balSheetCode = npfCharts.balSheetCode,
                              datecreated = npfCharts.datecreated,
                              createdby = npfCharts.createdby,
                              mainAccountCode_desc = npfmain.description,
                              balSheetCode_desc = npfbal.bl_desc,
                              subtype_desc = npfsubtype.subtypedesc,
                              compname = companyname,
                              compaddress = address
                          }).ToListAsync();


        }

        public async Task<List<ChartofAccountView>> getAllChartofAccounts_Desc()
        {

            return await (from npfCharts in context.nac_charts
                          join npfmain in context.nac_mainacts on npfCharts.mainAccountCode equals npfmain.maincode
                          join npfbal in context.nac_balsheets on npfCharts.balSheetCode equals npfbal.bl_code
                          join npfsubtype in context.nac_sub_Types on npfCharts.subtype equals npfsubtype.subtype
                          orderby npfCharts.acctcode
                          select new ChartofAccountView
                          {
                              Id = npfCharts.Id,
                              acctcode = npfCharts.acctcode,
                              description = npfCharts.description,
                              mainAccountCode = npfCharts.mainAccountCode,
                              subtype = npfCharts.subtype,
                              balSheetCode = npfCharts.balSheetCode,
                              datecreated = npfCharts.datecreated,
                              createdby = npfCharts.createdby,
                              mainAccountCode_desc = npfmain.description,
                              balSheetCode_desc = npfbal.bl_desc,
                              subtype_desc = npfsubtype.subtypedesc
                          }).ToListAsync();


        }

        public async Task<List<ChartofAccountView2>> getAllChartofAccounts_Desc2(int iDisplayStart, int iDisplayLength)
        {

            return await (from npfCharts in context.nac_charts
                          join npfmain in context.nac_mainacts on npfCharts.mainAccountCode equals npfmain.maincode
                          join npfbal in context.nac_balsheets on npfCharts.balSheetCode equals npfbal.bl_code
                          join npfsubtype in context.nac_sub_Types on npfCharts.subtype equals npfsubtype.subtype
                          orderby npfCharts.acctcode
                          select new ChartofAccountView2
                          {
                              Id = npfCharts.Id,
                              acctcode = npfCharts.acctcode,
                              description = npfCharts.description,
                              mainAccountCode = npfCharts.mainAccountCode,
                              subtype = npfCharts.subtype,
                              balSheetCode = npfCharts.balSheetCode,
                              mainAccountCode_desc = npfmain.description,
                              balSheetCode_desc = npfbal.bl_desc,
                              subtype_desc = npfsubtype.subtypedesc
                          }).Skip(iDisplayStart).Take(iDisplayLength).ToListAsync();


        }
        public async Task<int> getChartofAccountListCount()
        {
            return await (from npfCharts in context.nac_charts
                          join npfmain in context.nac_mainacts on npfCharts.mainAccountCode equals npfmain.maincode
                          join npfbal in context.nac_balsheets on npfCharts.balSheetCode equals npfbal.bl_code
                          join npfsubtype in context.nac_sub_Types on npfCharts.subtype equals npfsubtype.subtype
                          orderby npfCharts.acctcode
                          select new ChartofAccountView
                          {
                              Id = npfCharts.Id,
                              acctcode = npfCharts.acctcode,
                              description = npfCharts.description,
                              mainAccountCode = npfCharts.mainAccountCode,
                              subtype = npfCharts.subtype,
                              balSheetCode = npfCharts.balSheetCode,
                              datecreated = npfCharts.datecreated,
                              createdby = npfCharts.createdby,
                              mainAccountCode_desc = npfmain.description,
                              balSheetCode_desc = npfbal.bl_desc,
                              subtype_desc = npfsubtype.subtypedesc
                          }).CountAsync();


        }
        public async Task<List<ChartofAccountView>> getListChartofAccounts_DescBymainAccount(string actCode)
        {

            return await (from npfCharts in context.nac_charts
                          join npfmain in context.nac_mainacts on npfCharts.mainAccountCode equals npfmain.maincode
                          join npfbal in context.nac_balsheets on npfmain.nac_balsheet_bl_code equals npfbal.bl_code
                          join npfsubtype in context.nac_sub_Types on npfmain.subtype equals npfsubtype.subtypedesc
                          where npfmain.maincode == actCode
                          orderby npfCharts.acctcode
                          select new ChartofAccountView
                          {
                              Id = npfCharts.Id,
                              acctcode = npfCharts.acctcode,
                              description = npfCharts.description,
                              mainAccountCode = npfCharts.mainAccountCode,
                              subtype = npfCharts.subtype,
                              balSheetCode = npfCharts.balSheetCode,
                              datecreated = npfCharts.datecreated,
                              createdby = npfCharts.createdby,
                              mainAccountCode_desc = npfmain.description,
                              balSheetCode_desc = npfbal.bl_desc,
                              subtype_desc = npfsubtype.subtypedesc
                          }).ToListAsync();


        }


        public async Task<ChartofAccountView> getSingleChartofAccounts_Desc(string actcode)
        {

            return await (from npfCharts in context.nac_charts
                          join npfmain in context.nac_mainacts on npfCharts.mainAccountCode equals npfmain.maincode
                          join npfbal in context.nac_balsheets on npfmain.nac_balsheet_bl_code equals npfbal.bl_code
                          join npfsubtype in context.nac_sub_Types on npfmain.subtype equals npfsubtype.subtypedesc
                          where npfCharts.acctcode == actcode
                          orderby npfCharts.acctcode
                          select new ChartofAccountView
                          {
                              Id = npfCharts.Id,
                              acctcode = npfCharts.acctcode,
                              description = npfCharts.description,
                              mainAccountCode = npfCharts.mainAccountCode,
                              subtype = npfCharts.subtype,
                              balSheetCode = npfCharts.balSheetCode,
                              datecreated = npfCharts.datecreated,
                              createdby = npfCharts.createdby,
                              mainAccountCode_desc = npfmain.description,
                              balSheetCode_desc = npfbal.bl_desc,
                              subtype_desc = npfsubtype.subtypedesc
                          }).FirstOrDefaultAsync();


        }

        public async Task<nac_chart> GetChartofAccountByCode(Expression<Func<nac_chart, bool>> predicate)
        {
            return await context.nac_charts.FirstOrDefaultAsync(predicate);
        }
        public async Task<List<ChartofAccountView>> GetChartofAccountByCode1(string maincode)
        {
            return await (from npfCharts in context.nac_charts
                          where npfCharts.acctcode.Substring(0, 1) == "1" || npfCharts.acctcode.Substring(0, 1) == "2"
                          orderby npfCharts.acctcode
                          select new ChartofAccountView
                          {
                              Id = npfCharts.Id,
                              acctcode = npfCharts.acctcode,
                              description = npfCharts.description,

                          }).ToListAsync();
        }
        public async Task<List<ChartofAccountView>> GetChartofAccountByCode2(string maincode)
        {
            return await (from npfCharts in context.nac_charts
                          where npfCharts.acctcode.Substring(0, 1) == "1" || npfCharts.acctcode.Substring(0, 1) == "2"
                          orderby npfCharts.acctcode
                          select new ChartofAccountView
                          {
                              Id = npfCharts.Id,
                              acctcode = npfCharts.acctcode,
                              description = npfCharts.description,

                          }).ToListAsync();
        }
        public async Task<List<ChartofAccountView>> GetChartofAccountByCode3(string maincode)
        {
            return await (from npfCharts in context.nac_charts
                          where npfCharts.acctcode.Substring(0, 1) == "1" || npfCharts.acctcode.Substring(0, 1) == "2"
                          orderby npfCharts.acctcode
                          select new ChartofAccountView
                          {
                              Id = npfCharts.Id,
                              acctcode = npfCharts.acctcode,
                              description = npfCharts.description,

                          }).ToListAsync();
        }
        public async Task<List<ChartofAccountView>> GetChartofAccountByCode5(string maincode)
        {
            return await (from npfCharts in context.nac_charts
                          where npfCharts.acctcode.Substring(0, 1) == "4"
                          orderby npfCharts.acctcode
                          select new ChartofAccountView
                          {
                              Id = npfCharts.Id,
                              acctcode = npfCharts.acctcode,
                              description = npfCharts.description,

                          }).ToListAsync();
        }
        public async Task<List<ChartofAccountView>> GetChartofAccountByCode4(string maincode)
        {
            return await (from npfCharts in context.nac_charts
                          where npfCharts.subtype == maincode
                          orderby npfCharts.acctcode
                          select new ChartofAccountView
                          {
                              Id = npfCharts.Id,
                              acctcode = npfCharts.acctcode,
                              description = npfCharts.description,

                          }).ToListAsync();
        }


        public async Task<nac_chart> GetLasChartofAccountByCode(string maincode)
        {
            return await context.nac_charts.Where(x => x.acctcode.StartsWith(maincode) && x.ispersonel == false).OrderByDescending(y => y.acctcode).FirstOrDefaultAsync();
        }

        public nac_chart GetChartByDesc(string desc)
        {
            return context.nac_charts.FirstOrDefault(x => x.description.ToUpper() == desc.ToUpper());
        }
    }
}
