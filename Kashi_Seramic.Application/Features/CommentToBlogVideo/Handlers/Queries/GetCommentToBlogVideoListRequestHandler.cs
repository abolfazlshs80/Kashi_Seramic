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
    public class GetCommentToProductListRequestHandler : IRequestHandler<GetCommentToProductListRequest, List<CommentToProductDto>>
    {
        private readonly ICommentToProductRepository _rep_CommentToProduct;
        private readonly IMapper _mapper;

        public GetCommentToProductListRequestHandler(ICommentToProductRepository rep_CommentToProduct, IMapper mapper)
        {
            _rep_CommentToProduct = rep_CommentToProduct;
            _mapper = mapper;
        }

        public async Task<List<CommentToProductDto>> Handle(GetCommentToProductListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_CommentToProduct.GetCommentToBlogs();
            return _mapper.Map<List<CommentToProductDto>>(leaveTypes);
        }
    }
}
