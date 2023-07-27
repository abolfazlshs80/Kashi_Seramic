using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.Order.Requests.Commands;
using System.Linq;

namespace HR.LeaveManagement.Application.Features.Order.Handlers.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var Order =( await _unitOfWork.OrderRepository.GetAll()).Where(a=>a.Id== request.Id).FirstOrDefault();

            if (Order == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(Order), request.Id);

            await _unitOfWork.OrderRepository.Delete(Order);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
