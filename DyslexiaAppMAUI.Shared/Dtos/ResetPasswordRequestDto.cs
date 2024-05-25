using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaAppMAUI.Shared.Dtos
{
    public class ResetPasswordRequestDto
    {
        public string VerificationCode { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }

}