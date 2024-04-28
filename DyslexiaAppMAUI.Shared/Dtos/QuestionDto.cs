using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaAppMAUI.Shared.Dtos;

public class QuestionDto
{
    public Guid Id { get; set; }
    public string? QuestionText { get; set; }
    public ImageDto? MainImage { get; set; }
    public List<ImageDto>? ImageOptions { get; set; }
    public int CorrectAnswerIndex { get; set; }
}