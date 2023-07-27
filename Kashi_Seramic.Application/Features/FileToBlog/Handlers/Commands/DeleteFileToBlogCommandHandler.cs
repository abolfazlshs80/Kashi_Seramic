using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;


using Kashi_Seramic.Application.Features.FileToBlog.Requests.Commands;

namespace HR.LeaveManagement.Application.Features.FileToBlog.Handlers.Commands
{
    public class DeleteFileToBlogCommandHandler : IRequestHandler<DeleteFileToBlogCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFileToBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFileToBlogCommand request, CancellationToken cancellationToken)
        {
            //var FileImage = await _unitOfWork.FileToBlogRepository.Get(request.Id);

            //if (FileImage == null)
            //    throw new NotFoundException(nameof(FileImage), request.Id);

            await _unitOfWork.FileToBlogRepository.DeleteFileToBlogByBlogId(request.Id);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
