using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaAppMAUI.Shared.Dtos
{
    public class VerifyCodeRequestDto
    {
        public string Email { get; set; }
        public string Code { get; set; }
    }
}
