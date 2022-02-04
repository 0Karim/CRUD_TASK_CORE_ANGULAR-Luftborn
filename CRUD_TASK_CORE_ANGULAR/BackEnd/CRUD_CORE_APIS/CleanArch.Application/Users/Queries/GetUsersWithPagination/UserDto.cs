using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CleanArch.Application.Mapping;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Users.Queries
{
    public class UserDto : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string MobileNumber { get; set; }

        public string Email { get; set; }

        public int? GovId { get; set; }

        public int? CityId { get; set; }

        public string Street { get; set; }

        public string BuildingNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                //.ForMember(x => x.GovId, opt => opt.MapFrom(s => s.UserAddress.GovId))
                .ForMember(x => x.GovId, opt => opt.MapFrom(src => (int?)(src.UserAddress.GovId)))
                //.ForMember(x => x.CityId, opt => opt.MapFrom(s => s.UserAddress.City))
                .ForMember(x => x.CityId, opt => opt.MapFrom(src => (int?)(src.UserAddress.CityId)))
                .ForMember(x => x.BuildingNumber, opt => opt.MapFrom(s => s.UserAddress.BuildingNumber))
                .ForMember(x => x.Street, opt => opt.MapFrom(s => s.UserAddress.Street));
        }
    }
}
