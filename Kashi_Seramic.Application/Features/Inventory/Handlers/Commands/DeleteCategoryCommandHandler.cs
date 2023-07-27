using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

namespace Kashi_Seramic.Application.Features.Inventory.Handlers.Commands
{
    public class DeleteInventoryCommandHandler : IRequestHandler<DeleteInventoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteInventoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {
            var Inventory = await _unitOfWork.InventoryRepository.Get(request.Id);

            if (Inventory == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(Inventory), request.Id);

            await _unitOfWork.InventoryRepository.Delete(Inventory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
