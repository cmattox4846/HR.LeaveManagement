using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAllLeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.DeleteLeaveRequest
{
    public class DeleteLeaveRequestHandler : IRequestHandler<DeleteLeaveRequestCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IAppLogger<DeleteLeaveRequestHandler> _logger;

        public DeleteLeaveRequestHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository, IAppLogger<DeleteLeaveRequestHandler> logger)
        {
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
            _logger = logger;
        }



        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {

            //reteive to domain object

            var leaveRequestToDelete = await _leaveRequestRepository.GetByIdAsync(request.Id);

            //verify that record exsits

            if (leaveRequestToDelete == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.Id);
            }

            //delete from db

            await _leaveRequestRepository.DeleteAsync(leaveRequestToDelete);

            //return record Id

            return Unit.Value;
        }

       
    }
}
