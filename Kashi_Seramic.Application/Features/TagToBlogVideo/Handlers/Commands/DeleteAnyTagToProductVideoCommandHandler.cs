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
    public class DeleteAnyTagToProductVideoCommandHandler : IRequestHandler<DeleteAnyTagToProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAnyTagToProductVideoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAnyTagToProductCommand request, CancellationToken cancellationToken)
        {
            //   var TagToProductVideo = await _unitOfWork.TagToProductVideoRepository.Get(request.Id);

            //if (TagToProductVideo == null)
            //    throw new NotFoundException(nameof(TagToProductVideo), request.Id);
            var getAllTags =
                (await _unitOfWork.TagToProductRepository.GetAll()).Where(a => a.ProductId.Equals(request.Id));
            if (getAllTags != null)
            {
                foreach (var product in getAllTags)
                {
                    await _unitOfWork.TagToProductRepository.DeleteTagToProductByBlogId(product.ProductId);
                }

            }

            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
