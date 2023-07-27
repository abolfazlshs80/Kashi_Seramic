using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

namespace Kashi_Seramic.Application.Features.Slider.Handlers.Commands
{
    public class DeleteSliderCommandHandler : IRequestHandler<DeleteSliderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSliderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
        {
            var Slider = await _unitOfWork.SliderRepository.Get(request.Id);

            if (Slider == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(Slider), request.Id);

            await _unitOfWork.SliderRepository.Delete(Slider);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
