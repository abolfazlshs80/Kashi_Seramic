using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.FileToBlog;
using Kashi_Seramic.Application.Features.FileToBlog.Requests.Queries;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;


namespace Kashi_Seramic.Application.Features.FileToBlog.Handlers.Queries
{
    public class GetFileToBlogDetailRequestHandler : IRequestHandler<GetFileToBlogDetailRequest, FileToBlogDto>
    {
        private readonly IFileToBlogRepository _Repository;
        private readonly IMapper _mapper;

        public GetFileToBlogDetailRequestHandler(IFileToBlogRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<FileToBlogDto> Handle(GetFileToBlogDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetFileToBlogWithBlogId(request.Id);
            return _mapper.Map<FileToBlogDto>(leaveType);
        }
    }
}
