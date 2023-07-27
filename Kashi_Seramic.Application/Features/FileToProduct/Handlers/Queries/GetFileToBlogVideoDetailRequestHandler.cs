using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.FileToProduct.Requests.Queries;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;

using Kashi_Seramic.Application.DTOs.FileToProduct;

namespace Kashi_Seramic.Application.Features.FileToBlogVideo.Handlers.Queries
{
    public class GetFileToProductDetailRequestHandler : IRequestHandler<GetFileToProductDetailRequest, FileToProductDto>
    {
        private readonly IFileToProductRepository _Repository;
        private readonly IMapper _mapper;

        public GetFileToProductDetailRequestHandler(IFileToProductRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<FileToProductDto> Handle(GetFileToProductDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetFileToProductWithBlogId(request.Id);
            return _mapper.Map<FileToProductDto>(leaveType);
        }
    }
}
