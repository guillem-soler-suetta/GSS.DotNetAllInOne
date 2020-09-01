using AutoMapper;
using GSS.DotNetAllInOne.Application.Features.Examples.Queries;

namespace GSS.DotNetAllInOne.Application.Mappings
{
    public class ParametersMapping : Profile
    {
        public ParametersMapping()
        {
            CreateMap<ListExamplesQuery, ListExamplesParameter>();
        }

    }
}
