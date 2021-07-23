using AutoMapper;
using FixedAssetCore.Core.Entities;
using FixedAssetWeb.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FixedAssetWeb.Mappings
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>();
        }
       
    }
}
