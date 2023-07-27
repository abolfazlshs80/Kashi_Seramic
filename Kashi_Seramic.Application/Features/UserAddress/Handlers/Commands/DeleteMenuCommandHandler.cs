using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Exceptions;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteUserAddressCommandHandler : IRequestHandler<DeleteUserAddressCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteUserAddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteUserAddressCommand request, CancellationToken cancellationToken)
        {
            var UserAddress = await _unitOfWork.UserAddressRepository.Get(request.Id);

            if (UserAddress == null)
                throw new NotFoundException(nameof(UserAddress), request.Id);

            await _unitOfWork.UserAddressRepository.Delete(UserAddress);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
