using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.OrderDetials.Requests.Commands;

namespace HR.LeaveManagement.Application.Features.OrderDetials.Handlers.Commands
{
    public class DeleteOrderDetialsCommandHandler : IRequestHandler<DeleteOrderDetialsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteOrderDetialsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOrderDetialsCommand request, CancellationToken cancellationToken)
        {
            var OrderDetials =( await _unitOfWork.OrderDetailsRepository.GetAll()).Where(a=>a.Id== request.Id).FirstOrDefault();

            if (OrderDetials == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(OrderDetials), request.Id);

            await _unitOfWork.OrderDetailsRepository.Delete(OrderDetials);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
