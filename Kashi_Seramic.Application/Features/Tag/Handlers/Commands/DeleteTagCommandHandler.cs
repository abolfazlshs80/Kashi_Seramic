using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

namespace Kashi_Seramic.Application.Features.Tag.Handlers.Commands
{
    public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            var Tag = await _unitOfWork.TagRepository.Get(request.Id);

            if (Tag == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(Tag), request.Id);

            await _unitOfWork.TagRepository.Delete(Tag);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
