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
using Kashi_Seramic.Application.DTOs.TagToBlog.Validator;

namespace HR.LeaveManagement.Application.Features.TagToBlogToBlog.Handlers.Commands
{
    public class CreateTagToBlogToBlogCommandHandler : IRequestHandler<CreateTagToBlogCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTagToBlogToBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTagToBlogCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTagToBlogDtoValidator(_unitOfWork.TagToBlogRepository);
            var validationResult = await validator.ValidateAsync(request.CreateTagToBlogDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TagToBlog = _mapper.Map<TagToBlog>(request.CreateTagToBlogDto);

                //TagToBlog.CreatedBy = "abolfazl";
                //TagToBlog.DateCreated = DateTime.Now;
                //TagToBlog.LastModifiedDate = DateTime.Now;
                //TagToBlog.LastModifiedBy = "ali";
                TagToBlog = await _unitOfWork.TagToBlogRepository.Add(TagToBlog);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TagToBlog.BlogId;
            }

            return response;
        }
    }
}
