using AutoMapper;
using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.DataAccess.Entities;

namespace QuizMaster.BusinessLogic.Profiles.MappingConfigurations;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        //User mappingConfiguration
        CreateMap<UserRegistrationRequest, User>()
            .ForMember(dest => dest.UserName,
                options => options.MapFrom(source => source.Name)).ReverseMap();

        CreateMap<User, UserDto>()
            .ReverseMap();

        //Category mappingConfiguration
        CreateMap<CategoryRequest, Category>()
            .ForMember(dest => dest.Name, opt =>
                opt.MapFrom(src => src.Name));

        CreateMap<Category, CategoryDto>()
            .ReverseMap();

        //Mapping configuration for Question
        CreateMap<QuestionRequest, Question>()
            .ReverseMap();

        CreateMap<Question, QuestionDto>()
            .ForMember(dest => dest.answerOptions, opt =>
                opt.MapFrom(src => src.Options))
            .ReverseMap();

        //Mapping configuration for Quiz
        CreateMap<QuizRequest, Quiz>()
            .ReverseMap();

        CreateMap<Quiz, QuizDto>()
            .ForMember(dest => dest.UserName, opt =>
                opt.MapFrom(src => src.Creator.UserName))

            .ForMember(dest => dest.CategoryName, opt =>
                opt.MapFrom(src => src.Category.Name))
            .ReverseMap();


        //Mapping Configuration for AnswerOption
        CreateMap<AnswerOptionRequest, AnswerOption>()
            .ReverseMap();

        CreateMap<AnswerOption, AnswerOptionsDto>()
            .ForMember(dest => dest.QuestionText, opt =>
                opt.MapFrom(src => src.Question.QuestionTitle))

            .ForMember(dest => dest.OptionText, opt =>
                opt.MapFrom(src => src.Text))

            //.ForMember(dest => dest.Id, opt =>
            //    opt.MapFrom(src => src.OptionId))
            .ReverseMap();

        //QuizQuestion Mapping Configuration
        CreateMap<UserQuizFormRequest, QuizQuestion>()
            .ForMember(dest => dest.Question, opt =>
                opt.MapFrom(src => src.QuizQuestions))

            .ForMember(dest => dest.AnswerOption, opt =>
                opt.MapFrom(src => src.QuizQuestions));

        CreateMap<QuizQuestion, QuizQuestionDto>()
            .ForMember(dest => dest.QuestionText, opt =>
                opt.MapFrom(src => src.Question.QuestionTitle))

            .ForMember(dest => dest.AnswerOptions, opt =>
                opt.MapFrom(src => src.Question.Options))
            .ReverseMap();
    }
}
