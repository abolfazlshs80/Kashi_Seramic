using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

namespace Kashi_Seramic.Application.Features.Category.Handlers.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var Category = await _unitOfWork.CategoryRepository.Get(request.Id);

            if (Category == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(Category), request.Id);

            await _unitOfWork.CategoryRepository.Delete(Category);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
