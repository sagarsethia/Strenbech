using System;
using AutoMapper;
using Csvuploadapi.Dto;

namespace Csvuploadapi.Helper
{
    public class AutoMapperProfiles : Profile {
        public AutoMapperProfiles () {

            CreateMap<ReturnUploadedFileDto, ReturnUploadedFileDto>().ForMember 
                (dest => dest.CompanyName ,opt=> opt.MapFrom (src =>String.IsNullOrEmpty(src.CompanyName) ? Constants.CompanyName : src.CompanyName)).ForMember
                (dest => dest.SiteName ,opt=> opt.MapFrom (src =>String.IsNullOrEmpty(src.SiteName) ? Constants.SiteName : src.SiteName)).ForMember        
                (dest => dest.DepartmentId ,opt=> opt.MapFrom (src =>String.IsNullOrEmpty(src.DepartmentId) ? Constants.DepartmentId : src.DepartmentId));
            }
    }
}