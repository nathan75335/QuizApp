﻿namespace QuizMaster.BusinessLogic.Profiles.DTOs;

public class CategoryDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public List<QuizDto> Quizzes { get; set; }
}
