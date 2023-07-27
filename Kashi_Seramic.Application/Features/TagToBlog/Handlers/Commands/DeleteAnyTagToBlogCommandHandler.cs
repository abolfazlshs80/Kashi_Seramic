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
    public class DeleteAnyTagToBlogCommandHandler : IRequestHandler<DeleteAnyTagToBlogCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAnyTagToBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAnyTagToBlogCommand request, CancellationToken cancellationToken)
        {
            var getAllTags =
                (await _unitOfWork.TagToBlogRepository.GetAll()).Where(a => a.BlogId.Equals(request.Id));
            if (getAllTags != null)
            {
                foreach (var product in getAllTags)
                {
                    await _unitOfWork.TagToBlogRepository.DeleteTagToBlogByBlogId(product.BlogId);
                }

            }

            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
