using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{

    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {

        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocation(List<LeaveAllocation> allocation)
        {
            await _context.AddRangeAsync(allocation);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _context.LeaveAllocation.AnyAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId && q.Period == period);
        }

        public async Task<LeaveAllocation> GetLeaveAllocationsWithDetail(int id)
        {
            var leaveAllocation = await _context.LeaveAllocation.Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetail()
        {
            var leaveAllocation = await _context.LeaveAllocation.Include(q => q.LeaveType)
                .ToListAsync();
            return leaveAllocation;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
        {
            var leaveAllocation = await _context.LeaveAllocation.Where(q => q.EmployeeId == userId)
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveAllocation;
        }


        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            return await _context.LeaveAllocation.FirstOrDefaultAsync(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId);
        }
    }


}
