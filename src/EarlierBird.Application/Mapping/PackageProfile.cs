using AutoMapper;
using EarlierBird.Application.Models.Requests;
using EarlierBird.Domain.Entities;

namespace EarlierBird.Application.Mapping
{
    public class PackageProfile : Profile
    {
        public PackageProfile()
        {
            CreateMap<PackageCreateRequest, Package>();
        }
    }
}
