using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaAppMAUI.Shared.Dtos;

public record ChangePasswordDto(string OldPassword, string NewPassword, string ConfirmNewPassword);
