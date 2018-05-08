using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DbFirst;

namespace WebClient.Models
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<RestaurantInfo, RestaurantViewModel>()
                .ForSourceMember(src => src.ReviewerInfoes, opt => opt.Ignore());
            CreateMap<RestaurantViewModel, RestaurantInfo>()
                .ForMember(dst => dst.ReviewerInfoes, opt => opt.Ignore());
                
            CreateMap<ReviewerInfo, ReviewViewModel>()
                .ForSourceMember(src => src.RestaurantInfo, opt => opt.Ignore());
            CreateMap<ReviewViewModel, ReviewerInfo>()
                .ForMember(dst => dst.RestaurantInfo, opt => opt.Ignore());
            CreateMap<RestaurantInfo, RestaurantNameViewModel>()
                .ForSourceMember(src => src.restaurantId , opt => opt.Ignore())
                .ForSourceMember(src => src.City, opt => opt.Ignore())
                .ForSourceMember(src => src.Street, opt => opt.Ignore())
                .ForSourceMember(src => src.Email, opt => opt.Ignore())
                .ForSourceMember(src => src.Description, opt => opt.Ignore());

        }
    }
}