using AutoMapper;
using BT.Core.Repository.DbModel;
using BT.Model.ViewModel.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace BT.Core
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //account
            CreateMap<Account, AccountEntity>();
            CreateMap<AccountEntity, Account>();
            //
            CreateMap<Account, AccountRegisterEntity>();
            CreateMap<AccountRegisterEntity, Account>();
            //
            CreateMap<Roles, RolesEntity>();
            CreateMap<RolesEntity, Roles>();
            //
            CreateMap<Powers, PowersEntity>();
            CreateMap<PowersEntity, Powers>();
            //
            CreateMap<AccountRoles, AccountRolesEntity>();
            CreateMap<AccountRolesEntity, AccountRoles>();
        }
    }
}
