using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Entities;
using FixedAssetCore.Core.Repositories;
using FixedAssetCore.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedAssetCore.Repositories
{
    public class AssetMovement : Repository<fa_Assetsreg>, IAssetMovement
    {
        private readonly IAssetDbContext context;
        private readonly IUnitOfWork _unitOfWork;

        public AssetMovement(IAssetDbContext context) : base(context)
        {
        }

        public AssetMovement(IAssetDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            this.context = context;
            _unitOfWork = unitOfWork;
        }
        public Task<fa_Assetsreg> GetAllAssetsRegistered()
        {
            return context.fa_Assetsreg.FirstOrDefaultAsync();
        }

        public Task<fa_Assetsreg> GetAssetByCode(string code)
        {
            return context.fa_Assetsreg.FirstOrDefaultAsync(x => x.assetCode == code);
        }
        public Task<bool> UpdateAsset(fa_Assetsreg fa_reg)
        {
            context.fa_Assetsreg.Update(fa_reg);
            return _unitOfWork.Done();

            //_unitOfWork.reg.Update(fa_reg);

            //return _unitOfWork.Done();
            //var history = new fa_history
            //{
            //    assetCode = fa_reg.assetCode,

            //};
            //_unitOfWork.reg.Create(history);
        }
    }
}
