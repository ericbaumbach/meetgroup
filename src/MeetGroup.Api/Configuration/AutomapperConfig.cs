using AutoMapper;
using MeetGroup.Api.ViewModels;
using MeetGroup.Business.Models;

namespace MeetGroup.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Sala, SalaViewModel>().ReverseMap();
            CreateMap<Sala, SalaViewModel>().ReverseMap();
        }
    }
}