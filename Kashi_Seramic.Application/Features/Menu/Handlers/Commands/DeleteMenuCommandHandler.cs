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
    public class DeleteMenuCommandHandler : IRequestHandler<DeleteMenuCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMenuCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var Menu = await _unitOfWork.MenuRepository.Get(request.Id);

            if (Menu == null)
                throw new NotFoundException(nameof(Menu), request.Id);

            await _unitOfWork.MenuRepository.Delete(Menu);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
