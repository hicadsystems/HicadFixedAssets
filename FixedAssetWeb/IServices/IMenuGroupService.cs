using FixedAssetCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.IServices
{
    public interface IMenuGroupService
    {
        IEnumerable<fa_MenuGroup> GetActiveMenuGroups();
        IEnumerable<fa_MenuGroup> GetMenuGroupss();
    }
}
