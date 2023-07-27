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
    public class DeleteFilterToProductCommandHandler : IRequestHandler<DeleteFilterToProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFilterToProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFilterToProductCommand request, CancellationToken cancellationToken)
        {
            //var FilterImage = await _unitOfWork.FilterToProductRepository.Get(request.Id);

            //if (FilterImage == null)
            //    throw new NotFoundException(nameof(FilterImage), request.Id);

            await _unitOfWork.FilterToProductRepository.DeleteFilterToProductByBlogId(request.Id);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
