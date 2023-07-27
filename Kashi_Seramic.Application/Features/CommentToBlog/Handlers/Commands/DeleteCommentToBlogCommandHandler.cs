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
    public class DeleteCommentToBlogCommandHandler : IRequestHandler<DeleteCommentToBlogCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCommentToBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCommentToBlogCommand request, CancellationToken cancellationToken)
        {
            var CommentToBlog = await _unitOfWork.CommentToBlogRepository.Get(request.Id);

            if (CommentToBlog == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(CommentToBlog), request.Id);

            await _unitOfWork.CommentToBlogRepository.Delete(CommentToBlog);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
