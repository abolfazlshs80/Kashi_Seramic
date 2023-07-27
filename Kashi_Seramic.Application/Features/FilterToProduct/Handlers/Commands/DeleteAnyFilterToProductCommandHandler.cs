using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;


using Kashi_Seramic.Application.Features.FilterToProduct.Requests.Commands;

namespace HR.LeaveManagement.Application.Features.FilterToProduct.Handlers.Commands
{
    public class DeleteAnyFilterToProductCommandHandler : IRequestHandler<DeleteAnyFilterToProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAnyFilterToProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAnyFilterToProductCommand request, CancellationToken cancellationToken)
        {
            var getAllTags =
                (await _unitOfWork.FilterToProductRepository.GetAll()).Where(a => a.ProductId.Equals(request.Id));
            if (getAllTags != null)
            {
                foreach (var product in getAllTags)
                {
                    await _unitOfWork.FilterToProductRepository.DeleteFilterToProductByBlogId(product.ProductId);
                }

            }
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
