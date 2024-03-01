using Azure.Core;
using GCall.Application.Absractions.Services;
using GCall.Application.DTOs.Identity.AppUser;
using GCall.Application.Features.Commands.Identity.AppUser.Create;
using GCall.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T = GCall.Domain.Entities.Identity;

namespace GCall.Persistence.Services
{
    public class AppUserService : IAppUserService
    {
        readonly UserManager<T.AppUser> _userManager;

        public AppUserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponseDTO> CreateAsync(CreateUserRequestDTO model)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email,
            }, model.Password);

            CreateUserResponseDTO response = new() { Succeed = result.Succeeded };
            if (!result.Succeeded)
            {
                response.Message = "";
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description} \n ";
                }
            }

            return response;
        }
    }
}
