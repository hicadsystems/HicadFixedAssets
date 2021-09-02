using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.IRepositories;
using FixedAssetCore.EntityCoreVM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FixedAssetWeb.ViewModels.AssetMovementVM;
using System.Data;

namespace FixedAssetCore.Core.Repositories
{
    public class AssetRegistration : Repository<fa_Assetsreg>, IAssetRegistration
    {
        private readonly IAssetDbContext context;
        private readonly string connectionstring;

        public AssetRegistration(IAssetDbContext context, IConfiguration configuration) :base(context)
        {
            this.context = context;

            connectionstring = configuration.GetConnectionString("DefaultConnection");
        }
        public Task<fa_Assetsreg> getAssetRegByCode(string code)
        {
            return context.fa_Assetsreg.FirstOrDefaultAsync(x => x.assetCode == code);
        }

        public IEnumerable<AssetRegListVM> GetAllAssetRegisters()
        {
            var result = context.fa_Assetsreg
                .Join(context.fa_class, assetclass => assetclass.Class, c => c.classcode, (assetclass, c) => new { assetclass, c })
                .Join(context.nac_costcenters, al => al.assetclass.Dept, costcnt => costcnt.unitcode, (al, costcnt) => new { al.assetclass, al.c, costcnt })
                .Join(context.nac_businessline, abl => abl.assetclass.Busline, busline => busline.Code, (abl, busline) => new { abl.assetclass, abl.costcnt, abl.c, busline })
                .Select(assetRegVm => new AssetRegListVM
                {
                    Id = assetRegVm.assetclass.Id,
                    assetCode = assetRegVm.assetclass.assetCode,
                    assetDesc = assetRegVm.assetclass.assetDesc,
                    classCode = assetRegVm.assetclass.Class,
                    classDesc = assetRegVm.c.classdesc,
                    unitCode = assetRegVm.assetclass.Dept,
                    unitDesc = assetRegVm.costcnt.unitdesc,
                    busline = assetRegVm.assetclass.Busline,
                    buslineDesc = assetRegVm.busline.Description,
                    purchval = assetRegVm.assetclass.Purchval

                }).ToList();

            return result;
        }

        public string GenerateAssetsDepreciation(DateTime dateTime)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                using (SqlCommand sqlcommand = new SqlCommand("sp_GenerateDepreciationII", sqlConnection))
                {
                    sqlcommand.CommandTimeout = 1200;
                    sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcommand.Parameters.Add(new SqlParameter("@depdate", dateTime));

                    sqlcommand.Parameters.Add("@message", SqlDbType.Char, 500);
                    sqlcommand.Parameters["@message"].Direction = ParameterDirection.Output;

                    sqlConnection.Open();
                    sqlcommand.ExecuteNonQuery();
                    string message = sqlcommand.Parameters["@message"].Value.ToString();

                    return message;
                }
            }
        }

        public string AssetEval(fa_AssetRegVM fa_AssetRegVM)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                using (SqlCommand sqlcommand = new SqlCommand("sp_AssetRevaluation", sqlConnection))
                {
                    sqlcommand.CommandTimeout = 1200;
                    sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcommand.Parameters.Add(new SqlParameter("@assetCode", fa_AssetRegVM.assetCode));
                    sqlcommand.Parameters.Add(new SqlParameter("@Purchval", fa_AssetRegVM.Purchval));
                    sqlcommand.Parameters.Add(new SqlParameter("@Revaldate", fa_AssetRegVM.Revaldate));
                    sqlcommand.Parameters.Add(new SqlParameter("@Revalval", fa_AssetRegVM.Revalval));

                    sqlcommand.Parameters.Add("@message", SqlDbType.Char, 500);
                    sqlcommand.Parameters["@message"].Direction = ParameterDirection.Output;

                    sqlConnection.Open();
                    sqlcommand.ExecuteNonQuery();
                    string message = sqlcommand.Parameters["@message"].Value.ToString();

                    return message;
                }
            }
        }
    }
}
