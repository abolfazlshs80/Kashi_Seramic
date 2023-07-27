using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.FileManager.Requests.Queries;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.DTOs.FileManager;

namespace Kashi_Seramic.Application.Features.FileManager.Handlers.Queries
{
    public class GetFileManagerDetailRequestHandler : IRequestHandler<GetFileManagerDetailRequest, FileManagerDto>
    {
        private readonly IFileManagerRepository _Repository;
        private readonly IMapper _mapper;

        public GetFileManagerDetailRequestHandler(IFileManagerRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<FileManagerDto> Handle(GetFileManagerDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.Get(request.Id);
            return _mapper.Map<FileManagerDto>(leaveType);
        }
    }
}
