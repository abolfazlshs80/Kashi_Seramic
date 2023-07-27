using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.CommentToProduct.Requests.Commands;

namespace Kashi_Seramic.Application.Features.CommentToProduct.Handlers.Commands
{
    public class DeleteCommentToProductCommandHandler : IRequestHandler<DeleteCommentToProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCommentToProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCommentToProductCommand request, CancellationToken cancellationToken)
        {
            var CommentToProduct = await _unitOfWork.CommentToProductRepository.Get(request.Id);

            if (CommentToProduct == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(CommentToProduct), request.Id);

            await _unitOfWork.CommentToProductRepository.Delete(CommentToProduct);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
