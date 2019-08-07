using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Qks.Plugin.Core;
using Qks.Plugin.Application;

namespace Qks.Plugin.Application
{
    public class QksPluginMapProfile : Profile
    {
        public QksPluginMapProfile()
        {
            CreateMap<UserEntity, UserDto>().ReverseMap();
        }
    }
}
