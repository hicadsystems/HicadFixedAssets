using FixedAssetCore.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FixedAssetCore.Core.Entities
{
    public class UserRole:IdentityUserRole<int>
    {
        [NotMapped]
        [JsonIgnore]
        public virtual User User { get; set; }
        [NotMapped]
        public virtual Role Role { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
