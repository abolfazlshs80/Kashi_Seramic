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
    public class DeleteTagToBlogCommandHandler : IRequestHandler<DeleteTagToBlogCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTagToBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTagToBlogCommand request, CancellationToken cancellationToken)
        {
         //   var TagToBlog = await _unitOfWork.TagToBlogRepository.Get(request.Id);

            //if (TagToBlog == null)
            //    throw new NotFoundException(nameof(TagToBlog), request.Id);
       await     _unitOfWork.TagToBlogRepository.DeleteTagToBlogByBlogId(request.Id);
     
     
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
