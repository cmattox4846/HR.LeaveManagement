using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetail(int id);

        Task<List<LeaveRequest>> GetLeaveRequestsWithDetail();

        Task<List<LeaveRequest>> GetLeaveRequestWithDetails(string userId);

    }


}