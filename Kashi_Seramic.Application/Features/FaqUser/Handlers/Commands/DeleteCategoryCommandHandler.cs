using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

namespace Kashi_Seramic.Application.Features.FaqUser.Handlers.Commands
{
    public class DeleteFaqUserCommandHandler : IRequestHandler<DeleteFaqUserCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFaqUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFaqUserCommand request, CancellationToken cancellationToken)
        {
            var FaqUser = await _unitOfWork.FaqUserRepository.Get(request.Id);

            if (FaqUser == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(FaqUser), request.Id);

            await _unitOfWork.FaqUserRepository.Delete(FaqUser);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
