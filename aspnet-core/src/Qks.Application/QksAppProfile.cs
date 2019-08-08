using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Qks.Code;

namespace Qks
{
    public class QksAppProfile : Profile
    {
        public QksAppProfile()
        {
            CreateMap<Table, TableDto>().ReverseMap();
            CreateMap<Column, ColumnDto>().ReverseMap();
        }
    }
}
