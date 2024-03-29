﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizMaster.DataAccess.Entities;

/// <summary>
/// UserQuiz class, to keep track of the user after they finish answering a quiz
/// </summary>
public class UserQuiz
{
    [Key]
    public int UserQuizId { get; set; }

    [ForeignKey(nameof(User))]
    public int UserId { get; set; }
    public User User { get; set; }

    [ForeignKey(nameof(Quiz))]
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; }

}
