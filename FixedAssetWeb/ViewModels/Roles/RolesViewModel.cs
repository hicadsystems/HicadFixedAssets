using FixedAssetCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.ViewModels.Roles
{
    public class RolesViewModel
    {
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<fa_Menu> Menus { get; set; }
    }
}
