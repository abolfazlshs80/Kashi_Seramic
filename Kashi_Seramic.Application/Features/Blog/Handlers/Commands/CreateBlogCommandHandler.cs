using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.Linq;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;

using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.Blog.Requests.Commands;
using Pr_Signal_ir.Application.Extentions;
using Kashi_Seramic.Application.Responses;
using Kashi_Seramic.Application.DTOs.Blog.Validator;

namespace HR.LeaveManagement.Application.Features.Blog.Handlers.Commands
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBlogDtoValidator(_unitOfWork.BlogRepository);
            var validationResult = await validator.ValidateAsync(request.CreateBlogDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var newcodeClass = new ShortCode();
                var blog = _mapper.Map<Kashi_Seramic.Domain. Blog>(request.CreateBlogDto);

                blog.Seen = 0;
                blog.LinkKey = await newcodeClass.GetCodeValidForBlog(await _unitOfWork.BlogRepository.GetBlogsWithDetails());
                blog.Status = true;

           //     blog.CreatedBy = request.CreateBlogDto.CreatedBy;
                //blog.DateCreated = DateTime.Now;
                //blog.LastModifiedDate=DateTime.Now;
                //blog.LastModifiedBy = "ali"; 
                blog = await _unitOfWork.BlogRepository.Add(blog);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = blog.Id;
            }

            return response;
        }
    }
}
