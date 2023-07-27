using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;


using Kashi_Seramic.Application.Features.FileManager.Requests.Commands;

namespace HR.LeaveManagement.Application.Features.FileManager.Handlers.Commands
{
    public class DeleteFileManagerCommandHandler : IRequestHandler<DeleteFileManagerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFileManagerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFileManagerCommand request, CancellationToken cancellationToken)
        {
            var FileImage = await _unitOfWork.FileManagerRepository.Get(request.Id);

            if (FileImage == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(FileImage), request.Id);

            await _unitOfWork.FileManagerRepository.Delete(FileImage);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
