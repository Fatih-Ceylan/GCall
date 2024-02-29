﻿using GCall.Domain.Entities.Common;
using MediatR;

namespace GCall.Application.Features.Commands.Identity.AppUser.Create
{
    public class RequestCreateAppUser : BaseEntity, IRequest<ResponseCreateAppUser>
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}