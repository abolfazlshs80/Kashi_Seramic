using AutoMapper;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class DeleteSiteSettingCommandHandler : IRequestHandler<DeleteSiteSettingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSiteSettingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSiteSettingCommand request, CancellationToken cancellationToken)
        {
            var SiteSetting = await _unitOfWork.SiteSettingRepository.Get(request.Id);

            if (SiteSetting == null)
                throw new Kashi_Seramic.Application.Exceptions.NotFoundException(nameof(SiteSetting), request.Id);

            await _unitOfWork.SiteSettingRepository.Delete(SiteSetting);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
