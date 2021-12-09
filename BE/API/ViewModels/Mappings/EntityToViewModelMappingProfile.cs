using AutoMapper;
using WebShop.API.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.API.ViewModels.Mappings
{
    public class EntityToViewModelMappingProfile : Profile
    {
        public EntityToViewModelMappingProfile()
        {
            CreateMap<ShopItem, ShopItemViewModel>()
                .ReverseMap();

            CreateMap<ApiUser, UserViewModel>();

            CreateMap<IdentityRole, string>()
                .ConvertUsing(x => x.Name);
        }
    }
}
