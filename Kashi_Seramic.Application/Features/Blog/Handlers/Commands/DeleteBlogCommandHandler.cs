using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.Blog.Requests.Commands;

namespace HR.LeaveManagement.Application.Features.Blog.Handlers.Commands
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            var blog =( await _unitOfWork.BlogRepository.GetAll()).Where(a=>a.Id== request.Id).FirstOrDefault();

            if (blog == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(Blog), request.Id);

            await _unitOfWork.BlogRepository.Delete(blog);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
