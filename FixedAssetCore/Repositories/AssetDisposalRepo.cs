using FixedAssetCore.Core.Data;
using FixedAssetCore.Core.Repositories;
using FixedAssetCore.Entities;
using FixedAssetCore.IRepositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
    }
}
