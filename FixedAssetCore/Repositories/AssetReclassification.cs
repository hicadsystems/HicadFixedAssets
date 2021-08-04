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
                    sqlcommand.Parameters.Add(new SqlParameter("@assetdesc", fa_assetregVm.assetDesc));
                    sqlcommand.Parameters.Add(new SqlParameter("@Dept", /*fa_assetregVm.Dept*/ ""));
                    sqlcommand.Parameters.Add(new SqlParameter("@Busline", /*fa_assetregVm.Busline*/ ""));
                    sqlcommand.Parameters.Add(new SqlParameter("@Purchdate", /*fa_assetregVm.Purchdate*/ DateTime.Now));
                    sqlcommand.Parameters.Add(new SqlParameter("@Revaldate", /*fa_assetregVm.Revaldate*/ DateTime.Now));
                    sqlcommand.Parameters.Add(new SqlParameter("@Reclassdate", DateTime.Now));
                    sqlcommand.Parameters.Add(new SqlParameter("@movedate", DateTime.Now));
                    sqlcommand.Parameters.Add(new SqlParameter("@Dispdate", DateTime.Now));
                    sqlcommand.Parameters.Add(new SqlParameter("@Purchval", /*fa_assetregVm.Purchval*/ 0));
                    sqlcommand.Parameters.Add(new SqlParameter("@Accum_depre", /*fa_assetregVm.Accum_depre*/ 0));
                    sqlcommand.Parameters.Add(new SqlParameter("@Dispval", /*fa_assetregVm.Dispval*/  0));
                    sqlcommand.Parameters.Add(new SqlParameter("@Revalval", /*fa_assetregVm.Revalval*/ 0));
                    sqlcommand.Parameters.Add(new SqlParameter("@Insurdate", /*fa_assetregVm.Insurdate*/ DateTime.Now));
                    sqlcommand.Parameters.Add(new SqlParameter("@Insuredval", /*fa_assetregVm.Insuredval*/ 0));
                    sqlcommand.Parameters.Add(new SqlParameter("@oldClass", /*fa_assetregVm.oldClassCode*/ ""));
                    sqlcommand.Parameters.Add(new SqlParameter("@newLoc", /*fa_assetregVm.newLoc*/ ""));
                    sqlcommand.Parameters.Add(new SqlParameter("@oldLoc", /*fa_assetregVm.oldLoc*/ ""));
                    sqlcommand.Parameters.Add(new SqlParameter("@newRevalval", /*fa_assetregVm.newRevalval*/ 0));
                    sqlcommand.Parameters.Add(new SqlParameter("@oldRevalval", /*fa_assetregVm.oldRevalval*/ 0));
                    sqlcommand.Parameters.Add(new SqlParameter("@insrenewdate", DateTime.Now));
                    sqlcommand.Parameters.Add(new SqlParameter("@userid", "HiCAD"));
                    sqlcommand.Parameters.Add(new SqlParameter("@lastopendate", DateTime.Now));
                    sqlcommand.Parameters.Add(new SqlParameter("@period", /*fa_assetregVm.Period*/ ""));
                    sqlcommand.Parameters.Add(new SqlParameter("@oldrenewdate", /*fa_assetregVm.oldrenewdate*/ DateTime.Now));

                    sqlConnection.Open();
                    sqlcommand.ExecuteNonQuery();
                }
            }
        }
    }
}
