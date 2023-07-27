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
using Kashi_Seramic.Application.DTOs.Menu.Validator;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMenuCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMenuDtoValidator(_unitOfWork.MenuRepository);
            var validationResult = await validator.ValidateAsync(request.CreateMenuDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Menu = _mapper.Map<Menu>(request.CreateMenuDto);

                //Menu.Visit = 0;
                //Menu.LinkKey = "abc-12";
                //Menu.Status = true;
               
                //Menu.CreatedBy = "abolfazl";
                //Menu.DateCreated = DateTime.Now;
                //Menu.LastModifiedDate=DateTime.Now;
                //Menu.LastModifiedBy = "ali"; 
                Menu = await _unitOfWork.MenuRepository.Add(Menu);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Menu.Id;
            }

            return response;
        }
    }
}
