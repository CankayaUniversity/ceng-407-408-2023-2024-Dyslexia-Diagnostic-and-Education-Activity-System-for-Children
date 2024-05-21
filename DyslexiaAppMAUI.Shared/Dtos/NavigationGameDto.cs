using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaAppMAUI.Shared.Dtos;

public record struct NavigationGameDto(
    Guid Id,
    List <NavigationGameQuestionDto> Questions,
    string BaloonPosition
);




