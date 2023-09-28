using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{


    public class GetLeaveTypeQueryHandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<GetLeaveTypeQueryHandler> _logger;

        public GetLeaveTypeQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository, IAppLogger<GetLeaveTypeQueryHandler> logger)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
            this._logger = logger;

        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            // Query the database

            var leaveTypes = await _leaveTypeRepository.GetAsync();

            //covert data objects to DTO objects

            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            //return list of DTO objects
            _logger.LogInformation("Leave types were reteived successfully");

            return data;
        }
    }

}
