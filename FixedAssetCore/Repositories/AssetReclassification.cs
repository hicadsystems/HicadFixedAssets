using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.Repositories;
using FixedAssetCore.EntityCoreVM;
using FixedAssetCore.IRepositories;
using FixedAssetWeb.ViewModels.AssetMovementVM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Repositories
{
    public class AssetReclassification : Repository<fa_Assetsreg>, IAssetReclassification
    {
        private readonly IAssetDbContext context;
        private readonly string connectionstring;

        public AssetReclassification(IAssetDbContext context, IConfiguration configuration) : base(context)
        {
            this.context = context;
            connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public ClassDescriptionVM GetClassDescription(string assetcode)
        {
            var result = context.fa_Assetsreg.Where(x => x.assetCode == assetcode)
                .Join(context.fa_class, asset => asset.Class, c => c.classcode, (asset, c) => new { asset, c })
                .Select(y => new ClassDescriptionVM
                {
                    AssetCode = y.asset.assetCode,
                    oldClassCode = y.c.classcode,
                    ClassDescription = y.c.classdesc
                }).FirstOrDefault();

            return result;
        }

        public void UpdateAssetReg(fa_AssetRegVM fa_assetregVm)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                using (SqlCommand sqlcommand = new SqlCommand("sp_UpdateAssetRegister", sqlConnection))
                {
                    sqlcommand.CommandTimeout = 1200;
                    sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcommand.Parameters.Add(new SqlParameter("@assetCode", fa_assetregVm.assetCode));
                    sqlcommand.Parameters.Add(new SqlParameter("@newCLass", fa_assetregVm.newClassCode));
                    sqlcommand.Parameters.Add(new SqlParameter("@Reclassdate", fa_assetregVm.Reclassdate));
                    sqlcommand.Parameters.Add(new SqlParameter("@userid", fa_assetregVm.userId));

                    sqlcommand.Parameters.Add("@message", SqlDbType.Char, 500);
                    sqlcommand.Parameters["@message"].Direction = ParameterDirection.Output;

                    sqlConnection.Open();
                    sqlcommand.ExecuteNonQuery();
                    string message = sqlcommand.Parameters["@message"].Value.ToString();
                }
            }
        }
    }
}
