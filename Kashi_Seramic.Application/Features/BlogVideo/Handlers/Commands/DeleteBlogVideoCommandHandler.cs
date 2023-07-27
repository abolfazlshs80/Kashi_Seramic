using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Kashi_Seramic.Application.Features.Product.Requests.Commands;
using System.Linq;

namespace HR.LeaveManagement.Application.Features.Product.Handlers.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var Product =( await _unitOfWork.ProductRepository.GetAll()).Where(a=>a.Id== request.Id).FirstOrDefault();

            if (Product == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(Product), request.Id);

            await _unitOfWork.ProductRepository.Delete(Product);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
