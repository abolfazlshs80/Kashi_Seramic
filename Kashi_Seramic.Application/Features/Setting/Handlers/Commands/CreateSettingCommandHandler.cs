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
using Kashi_Seramic.Application.DTOs.SiteSetting.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateSiteSettingCommandHandler : IRequestHandler<CreateSiteSettingCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSiteSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSiteSettingCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSiteSettingDtoValidator(_unitOfWork.SiteSettingRepository);
            var validationResult = await validator.ValidateAsync(request.CreateSiteSettingDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SiteSetting = _mapper.Map<SiteSetting>(request.CreateSiteSettingDto);

                //SiteSetting.Visit = 0;
                //SiteSetting.LinkKey = "abc-12";
                //SiteSetting.Status = true;
               
                //SiteSetting.CreatedBy = "abolfazl";
                //SiteSetting.DateCreated = DateTime.Now;
                //SiteSetting.LastModifiedDate=DateTime.Now;
                //SiteSetting.LastModifiedBy = "ali"; 
                SiteSetting = await _unitOfWork.SiteSettingRepository.Add(SiteSetting);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SiteSetting.Id;
            }

            return response;
        }
    }
}
