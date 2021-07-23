using FixedAssetCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.ViewModels.Menus
{
    public class MenusViewModel
    {
        public IEnumerable<fa_Menu> Menus { get; set; }
        public IEnumerable<fa_MenuGroup> MenuGroups { get; set; }
    }
}
