using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

namespace Kashi_Seramic.Application.Features.FilterValueProduct.Handlers.Commands
{
    public class DeleteFilterValueProductCommandHandler : IRequestHandler<DeleteFilterValueProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFilterValueProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFilterValueProductCommand request, CancellationToken cancellationToken)
        {
            var FilterValueProduct = await _unitOfWork.FilterValueProductRepository.GetFilterValueProductWithDetails(request.Id);

            if (FilterValueProduct == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(FilterValueProduct), request.Id);

            await _unitOfWork.FilterValueProductRepository.Delete(FilterValueProduct);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
