using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

namespace Kashi_Seramic.Application.Features.TagToProductVideoVideo.Handlers.Commands
{
    public class DeleteTagToProductVideoCommandHandler : IRequestHandler<DeleteTagToProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTagToProductVideoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTagToProductCommand request, CancellationToken cancellationToken)
        {
            //   var TagToProductVideo = await _unitOfWork.TagToProductVideoRepository.Get(request.Id);

            //if (TagToProductVideo == null)
            //    throw new NotFoundException(nameof(TagToProductVideo), request.Id);
            await _unitOfWork.TagToProductRepository.DeleteTagToProductByBlogId(request.Id);


            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
