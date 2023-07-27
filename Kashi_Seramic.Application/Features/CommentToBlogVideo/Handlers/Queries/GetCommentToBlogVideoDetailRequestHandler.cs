using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.CommentToProduct.Requests.Queries;
using Kashi_Seramic.Application.DTOs.CommentToProduct;

namespace Kashi_Seramic.Application.Features.CommentToProduct.Handlers.Queries
{
    public class GetCommentToProductDetailRequestHandler : IRequestHandler<GetCommentToProductDetailRequest, CommentToProductDto>
    {
        private readonly ICommentToProductRepository _Repository;
        private readonly IMapper _mapper;

        public GetCommentToProductDetailRequestHandler(ICommentToProductRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<CommentToProductDto> Handle(GetCommentToProductDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetCommentToProductWithDCommentId(request.Id);
            return _mapper.Map<CommentToProductDto>(leaveType);
        }
    }
}
