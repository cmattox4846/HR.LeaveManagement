using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAllLeaveRequest
{
    public record GetLeaveRequestQuery : IRequest<List<LeaveRequestDto>>;

}
