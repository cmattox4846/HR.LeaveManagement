using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Commands.DeleteLeaveLAllocation
{

    public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            this._leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;

        }


        public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {


            //Get Leaave type for Allocations
            var leaveAllocationDelete = await _leaveAllocationRepository.GetByIdAsync(request.Id);

            if (leaveAllocationDelete is null)
            {
                throw new NotFoundException(nameof(leaveAllocationDelete), request.Id);
            }

            await _leaveAllocationRepository.DeleteAsync(leaveAllocationDelete);
            return Unit.Value;
        }
    }
}

