using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FixedAssetCore.Core.Entities
{
    public class fa_MenuGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [JsonIgnore]
        public List<fa_Menu> fa_Menus { get; set; }
    }
}
