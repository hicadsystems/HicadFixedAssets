using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.Repositories;
using FixedAssetCore.EntityCoreVM;
using FixedAssetCore.IRepositories;
using FixedAssetWeb.ViewModels.AssetMovementVM;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace FixedAssetCore.Repositories
{
    public class AssetMovementRepository : Repository<fa_Assetsreg>, IAssetMovementRepository
    {
        private readonly IAssetDbContext context;
        private readonly string connectionstring;
        public AssetMovementRepository(IAssetDbContext context, IConfiguration configuration) : base(context)
        {
            this.context = context;
            connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public CostCenterDescriptionVM GetCenterDescription(string assetcode)
        {
            var result = context.fa_Assetsreg.Where(x => x.assetCode == assetcode)
                .Join(context.nac_costcenters, asset => asset.Dept, c => c.unitcode, (asset, c) => new { asset, c })
                .Select(y => new CostCenterDescriptionVM
                {
                    AssetCode = y.asset.assetCode,
                    oldUnitCode = y.c.unitcode,
                    UnitCodeDescription = y.c.unitdesc
                }).FirstOrDefault();

            return result;
        }

        public void UpdateAssetRegDept(fa_AssetRegVM fa_assetregVm)
        {
       
            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                using (SqlCommand sqlcommand = new SqlCommand("sp_UpdateAssetMovementRegister", sqlConnection))
                {
                    sqlcommand.CommandTimeout = 1200;
                    sqlcommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlcommand.Parameters.Add(new SqlParameter("@assetCode", fa_assetregVm.assetCode));
                    sqlcommand.Parameters.Add(new SqlParameter("@newLoc", fa_assetregVm.newUnitCode));
                    sqlcommand.Parameters.Add(new SqlParameter("@movedate", fa_assetregVm.movedate));
                    sqlcommand.Parameters.Add(new SqlParameter("@userid",fa_assetregVm.userId));

                    sqlcommand.Parameters.Add("@message", SqlDbType.Char, 500);
                    sqlcommand.Parameters["@message"].Direction = ParameterDirection.Output;

                    sqlConnection.Open();
                    sqlcommand.ExecuteNonQuery();
                    string message = sqlcommand.Parameters["@message"].Value.ToString();
                }
            }
        }

        public IEnumerable<fa_historyVM> GetAssetNovementList(SortAssetsRegListVM sortAssetsRegListVM)
        {
            if (sortAssetsRegListVM.classDept != "null" && sortAssetsRegListVM.classDept != "")
            {
                var result = context.fa_historys.Where(assets => assets.newloc == sortAssetsRegListVM.classDept.Trim() &&
                                                   (assets.movedate >= sortAssetsRegListVM.startDate && assets.movedate <= sortAssetsRegListVM.endDate))
                .Join(context.nac_costcenters, al => al.oldloc, costcnt => costcnt.unitcode, (al, costcnt) => new { al, costcnt })
                .Join(context.nac_costcenters, al2 => al2.al.newloc, costcnt2 => costcnt2.unitcode, (al2, costcnt2) => new { al2, al2.al, al2.costcnt, costcnt2 })
                .Select(movementVm => new fa_historyVM
                {
                    Id = movementVm.al.Id,
                    assetCode = movementVm.al.assetCode,
                    assetdesc = movementVm.al.assetdesc,
                    oldloc = movementVm.costcnt.unitdesc,
                    newloc = movementVm.costcnt2.unitdesc,
                    movedate = movementVm.al.movedate

                }).ToList();

                return result;
            }
            else
            {
                var result = context.fa_historys.Where(assets => assets.movedate >= sortAssetsRegListVM.startDate && assets.movedate <= sortAssetsRegListVM.endDate)
              .Join(context.nac_costcenters, al => al.oldloc, costcnt => costcnt.unitcode, (al, costcnt) => new { al, costcnt })
              .Join(context.nac_costcenters, al2 => al2.al.newloc, costcnt => costcnt.unitcode, (al2, costcnt) => new { al2.al, costcnt })
              .Select(movementVm => new fa_historyVM
              {
                  Id = movementVm.al.Id,
                  assetCode = movementVm.al.assetCode,
                  assetdesc = movementVm.al.assetdesc,
                  oldloc = movementVm.costcnt.unitdesc,
                  newloc = movementVm.costcnt.unitdesc,
                  movedate = movementVm.al.movedate

              }).ToList();

                return result;
            }
        }
    }
}
