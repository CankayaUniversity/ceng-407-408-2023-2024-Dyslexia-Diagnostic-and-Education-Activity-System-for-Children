using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaAppMAUI.Shared.Dtos;

public class UserAnswerDto
{
    public Guid QuestionId { get; set; }
    public int SelectedAnswerIndex { get; set; }
}

public class UserAnswersDto
{
    public List<UserAnswerDto> UserAnswers { get; set; }
}

public class DyslexiaResultDto
{
    public double AccuracyRate { get; set; }
    public string DyslexiaRate { get; set; }
}

