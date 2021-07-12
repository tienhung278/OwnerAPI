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
            CreateMap<OwnerForCreate, Owner>();
            CreateMap<OwnerForUpdate, Owner>();
            CreateMap<DateTime, string>().ConvertUsing(d => d.ToString("dd/MM/yyyy"));
            CreateMap<string, DateTime>().ConvertUsing(t => DateTime.Parse(t, new CultureInfo("vi-VN")));
        }
    }
}