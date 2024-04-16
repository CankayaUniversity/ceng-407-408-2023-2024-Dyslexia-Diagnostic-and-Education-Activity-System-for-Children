﻿using DyslexiaAppMAUI.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaAppMAUI.Shared.Dtos;

public record SignupRequestDto(string Name, string LastName, string Gender, string Email, string Password, DateTime Birthday);



