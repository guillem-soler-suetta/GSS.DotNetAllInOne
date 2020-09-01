using AutoMapper;
using GSS.DotNetAllInOne.Application.Wrappers;
using GSS.DotNetAllInOne.Domain.Entities;
using GSS.DotNetAllInOne.Domain.Interfaces.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GSS.DotNetAllInOne.Application.Features.Examples.Queries
{
    public class ListExamplesQuery : IRequest<PagedResponse<IEnumerable<Example>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    internal class ListExamplesQueryHandler : IRequestHandler<ListExamplesQuery, PagedResponse<IEnumerable<Example>>>
    {
        private readonly IExampleRepository _exampleRepository;
        private readonly IMapper _mapper;

        public ListExamplesQueryHandler(IExampleRepository exampleRepository, IMapper mapper)
        {
            _exampleRepository = exampleRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<Example>>> Handle(ListExamplesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<ListExamplesParameter>(request);
            var example = await _exampleRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);;
            return new PagedResponse<IEnumerable<Example>>(example, validFilter.PageNumber, validFilter.PageSize);
        }

    }
}
