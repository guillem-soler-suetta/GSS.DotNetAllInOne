using AutoMapper;
using GSS.DotNetAllInOne.Application.Wrappers;
using GSS.DotNetAllInOne.Domain.Entities;
using GSS.DotNetAllInOne.WebAPI.DTOs;
using System.Collections.Generic;

namespace GSS.DotNetAllInOne.WebAPI.Mappings
{
    public class ExampleMapping : Profile
    {
        public ExampleMapping()
        {
            CreateMap<PagedResponse<IEnumerable<ExampleDTO>>, PagedResponse<IEnumerable<Example>>>();
            CreateMap<ExampleDTO, Example>()
                  .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Example, ExampleDTO>();
        }
    }
}
