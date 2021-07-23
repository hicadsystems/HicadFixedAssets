using Microsoft.EntityFrameworkCore;
using System;


namespace FixedAssetCore.Core.Data
{
    public interface IDbContext :IDisposable
    {
        DbContext Instance { get; }
    }
}
