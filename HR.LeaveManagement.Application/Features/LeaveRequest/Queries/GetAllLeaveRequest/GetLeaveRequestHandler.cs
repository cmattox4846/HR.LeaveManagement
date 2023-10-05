using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAllLeaveRequest
{
    public class GetLeaveRequestHandler : IRequestHandler<GetLeaveRequestQuery, List<LeaveRequestDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IAppLogger<GetLeaveRequestHandler> _logger;

        public GetLeaveRequestHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository, IAppLogger<GetLeaveRequestHandler> logger)
        {
            _mapper = mapper;
            _leaveRequestRepository = leaveRequestRepository;
            _logger = logger;
        }




        public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestQuery request, CancellationToken cancellationToken)
        {
            //Query the DB 
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestWithDetails();

            //Convert to object
            var requests = _mapper.Map<List<LeaveRequestDto>>(leaveRequest);

            //Log Success
            _logger.LogInformation("Leave request were reteived successfully");

            //Return object
            return requests;
        }
    }
}

