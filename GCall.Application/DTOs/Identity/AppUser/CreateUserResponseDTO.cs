using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCall.Application.DTOs.Identity.AppUser
{
    public class CreateUserResponseDTO
    {
        public bool Succeed { get; set; } = false;
        public string Message { get; set; } = "User Created Successfully";
    }
}
