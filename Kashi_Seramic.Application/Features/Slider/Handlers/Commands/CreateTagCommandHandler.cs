using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Responses;
using Kashi_Seramic.Application.DTOs.Slider.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateSliderCommandHandler : IRequestHandler<CreateSliderCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSliderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSliderDtoValidator(_unitOfWork.SliderRepository);
            var validationResult = await validator.ValidateAsync(request.CreateSliderDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Slider = _mapper.Map<Slider>(request.CreateSliderDto);

                //Slider.CreatedBy = "abolfazl";
                //Slider.DateCreated = DateTime.Now;
                //Slider.LastModifiedDate = DateTime.Now;
                //Slider.LastModifiedBy = "ali";
                Slider = await _unitOfWork.SliderRepository.Add(Slider);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Slider.Id;
            }

            return response;
        }
    }
}
