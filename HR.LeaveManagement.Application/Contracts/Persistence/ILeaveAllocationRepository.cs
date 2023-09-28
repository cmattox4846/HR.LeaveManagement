using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {

        Task<LeaveAllocation> GetLeaveAllocationsWithDetail(int id);

        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetail();

        Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId);

        Task<bool> AllocationExists(string userId, int leaveTypeId, int period);

        Task AddAllocation(List<LeaveAllocation> allocation);

        Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);




    }


}