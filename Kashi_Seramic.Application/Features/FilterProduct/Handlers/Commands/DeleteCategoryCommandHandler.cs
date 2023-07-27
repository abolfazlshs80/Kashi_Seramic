using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

namespace Kashi_Seramic.Application.Features.FilterProduct.Handlers.Commands
{
    public class DeleteFilterProductCommandHandler : IRequestHandler<DeleteFilterProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFilterProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFilterProductCommand request, CancellationToken cancellationToken)
        {
            var FilterProduct = await _unitOfWork.FilterProductRepository.Get(request.Id);

            if (FilterProduct == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(FilterProduct), request.Id);

            await _unitOfWork.FilterProductRepository.Delete(FilterProduct);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
