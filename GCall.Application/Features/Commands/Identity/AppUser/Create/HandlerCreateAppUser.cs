using MediatR;
using GCall.Application.Absractions.Services;
using AutoMapper;
using GCall.Application.DTOs.Identity.AppUser;

namespace GCall.Application.Features.Commands.Identity.AppUser.Create
{
    public class HandlerCreateAppUser : IRequestHandler<RequestCreateAppUser, ResponseCreateAppUser>
    {
        readonly IAppUserService _appUserService;
        readonly IMapper _mapper;

        public HandlerCreateAppUser(IAppUserService appUserService, IMapper mapper)
        {
            _appUserService = appUserService;
            _mapper = mapper;
        }

        public async Task<ResponseCreateAppUser> Handle(RequestCreateAppUser request, CancellationToken cancellationToken)
        {
            var appUserRequestDto = _mapper.Map<CreateUserRequestDTO>(request);
            var appUserResponseDto = await _appUserService.CreateAsync(appUserRequestDto);

            return _mapper.Map<ResponseCreateAppUser>(appUserResponseDto);
        }
    }
}
