using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Commands.DeleteLeaveLAllocation
{
    public class DeleteLeaveAllocationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
