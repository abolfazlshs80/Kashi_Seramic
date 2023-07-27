using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;


using Kashi_Seramic.Application.Features.FileToProduct.Requests.Commands;

namespace HR.LeaveManagement.Application.Features.FileToProduct.Handlers.Commands
{
    public class DeleteFileToProductCommandHandler : IRequestHandler<DeleteFileToProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFileToProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFileToProductCommand request, CancellationToken cancellationToken)
        {
            //var FileImage = await _unitOfWork.FileToProductRepository.Get(request.Id);

            //if (FileImage == null)
            //    throw new NotFoundException(nameof(FileImage), request.Id);

            await _unitOfWork.FileToProductRepository.DeleteFileToProductByBlogId(request.Id);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
