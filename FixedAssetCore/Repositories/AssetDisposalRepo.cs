using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Repositories;
using FixedAssetCore.Entities;
using FixedAssetCore.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FixedAssetCore.Repositories
{
    public class AssetDisposalRepo : Repository<fa_assetDisposal>, IAssetDisposalRepo
    {
        private readonly IAssetDbContext context;
        private readonly string connectionstring;
        public AssetDisposalRepo(IAssetDbContext context, IConfiguration configuration) : base(context)
        {
            this.context = context;
            connectionstring = configuration.GetConnectionString("DefaultConnection");

        }

        public string AssetDisposal(string assetcode, decimal? currentValue)
        {
            try
            {
                var assetInDb = context.fa_Assetsreg.FirstOrDefault(x => x.assetCode == assetcode.Trim());

                if (assetInDb == null)
                {
                    return "No Record Found for Asset with code " + assetcode;
                }
                else
                {
                    assetInDb.Dispdate = DateTime.Now;
                    assetInDb.Dispval = currentValue;

                    context.fa_Assetsreg.Update(assetInDb);

                    fa_assetDisposal disposedAsset = new fa_assetDisposal()
                    {
                        assetCode = assetInDb.assetCode,
                        assetDesc = assetInDb.assetDesc,
                        Class = assetInDb.Class,
                        Dept = assetInDb.Dept,
                        Busline = assetInDb.Busline,
                        Purchdate = assetInDb.Purchdate,
                        Revaldate = assetInDb.Revaldate,
                        Reclassdate  = assetInDb.Reclassdate,
                        movedate = assetInDb.movedate,
                        Dispdate = assetInDb.Dispdate,
                        Purchval = assetInDb.Purchval,
                        Accum_depre = assetInDb.Accum_depre,
                        Dispval = assetInDb.Dispval,
                        Revalval = assetInDb.Revalval,
                        Insurdate = assetInDb.Insurdate,
                        Insuredval = assetInDb.Insuredval,
                        year_depr = assetInDb.year_depr,
                        depr_rate = assetInDb.depr_rate,
                    };

                    context.fa_AssetDisposals.Add(disposedAsset);

                    return "Asset with code " + assetcode + " Disposed Succesfully!!";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
