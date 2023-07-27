using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

namespace Kashi_Seramic.Application.Features.OrderSatus.Handlers.Commands
{
    public class DeleteOrderSatusCommandHandler : IRequestHandler<DeleteOrderSatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOrderSatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOrderSatusCommand request, CancellationToken cancellationToken)
        {
            var OrderSatus = await _unitOfWork.OrderSatusRepository.Get(request.Id);

            if (OrderSatus == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(OrderSatus), request.Id);

            await _unitOfWork.OrderSatusRepository.Delete(OrderSatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
