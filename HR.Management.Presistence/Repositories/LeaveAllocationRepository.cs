using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Presistence.DatabaseContext;

namespace HR.LeaveManagement.Presistence.Repositories
{

    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {

        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }

    }


}
