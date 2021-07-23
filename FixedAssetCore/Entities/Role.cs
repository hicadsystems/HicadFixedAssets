using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FixedAssetCore.Core.Entities
{
    public class Role: IdentityRole<int>
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public ICollection<fa_RoleMenu> fa_RoleMenus { get; set; }

        [JsonIgnore]
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
