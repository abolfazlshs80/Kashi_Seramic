using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

namespace Kashi_Seramic.Application.Features.CategoryToProductVideoVideo.Handlers.Commands
{
    public class DeleteCategoryToProductVideoCommandHandler : IRequestHandler<DeleteCategoryToProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCategoryToProductVideoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCategoryToProductCommand request, CancellationToken cancellationToken)
        {
            //   var CategoryToProductVideo = await _unitOfWork.CategoryToProductVideoRepository.Get(request.Id);

            //if (CategoryToProductVideo == null)
            //    throw new NotFoundException(nameof(CategoryToProductVideo), request.Id);
            await _unitOfWork.CategoryToProductRepository.DeleteCategoryToProductByBlogId(request.Id);


            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
