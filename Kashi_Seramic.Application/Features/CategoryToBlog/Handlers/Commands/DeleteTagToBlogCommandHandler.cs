using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteCategoryToBlogCommandHandler : IRequestHandler<DeleteCategoryToBlogCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCategoryToBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCategoryToBlogCommand request, CancellationToken cancellationToken)
        {
         //   var CategoryToBlog = await _unitOfWork.CategoryToBlogRepository.Get(request.Id);

            //if (CategoryToBlog == null)
            //    throw new NotFoundException(nameof(CategoryToBlog), request.Id);
       await     _unitOfWork.CategoryToBlogRepository.DeleteCategoryToBlogByBlogId(request.Id);
     
     
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
