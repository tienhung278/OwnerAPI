using System;
using System.Globalization;
using AutoMapper;
using OwnerAPI.Dtos;
using OwnerAPI.Entities;

namespace OwnerAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerForRead>();
            CreateMap<Owner, OwnerDetailsForRead>();
            CreateMap<OwnerForCreate, Owner>();
            CreateMap<OwnerForUpdate, Owner>();            
            CreateMap<DateTime, string>().ConvertUsing(d => d.ToString("dd/MM/yyyy"));            
            CreateMap<string, DateTime>().ConvertUsing(t => DateTime.Parse(t, new CultureInfo("vi-VN")));

            CreateMap<Account, AccountForRead>();
            CreateMap<Account, AccountDetailsForRead>();
            CreateMap<AccountForCreate, Account>();            
            CreateMap<AccountForUpdate, Account>();
            CreateMap<string, Guid>().ConvertUsing(t => new Guid(t));
        }
    }
}