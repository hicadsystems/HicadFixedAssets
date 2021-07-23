using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.Core.Entities
{
    public class fa_RoleMenu
    {
        public int Id { get; set; }

        public fa_Menu fa_Menu { get; set; }
        public int MenuId { get; set; }

        [JsonIgnore]
        public Role Role { get; set; }
        public int RoleId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
