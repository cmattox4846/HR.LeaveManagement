using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Queries.GetLeaveAllocations
{
    public record GetLeaveAllocationListQuery : IRequest<List<LeaveAllocationDto>>;

}
