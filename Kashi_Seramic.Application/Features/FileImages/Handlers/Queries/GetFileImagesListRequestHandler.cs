using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.DTOs.Blog;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.FileManager.Requests.Queries;
using Kashi_Seramic.Application.DTOs.FileManager;

namespace Kashi_Seramic.Application.Features.FileManager.Handlers.Queries
{
    public class GetFileManagerListRequestHandler : IRequestHandler<GetFileManagerListRequest, List<FileManagerDto>>
    {
        private readonly IFileManagerRepository _rep_cate;
        private readonly IMapper _mapper;

        public GetFileManagerListRequestHandler(IFileManagerRepository rep_cate, IMapper mapper)
        {
            _rep_cate = rep_cate;
            _mapper = mapper;
        }

        public async Task<List<FileManagerDto>> Handle(GetFileManagerListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_cate.GetAll();
            return _mapper.Map<List<FileManagerDto>>(leaveTypes);
        }
    }
}
