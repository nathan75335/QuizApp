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
                options => options.MapFrom(source => source.Name));

        CreateMap<User, UserDto>()
            .ReverseMap();

        //Category mappingConfiguration
        CreateMap<CategoryRequest, Category>()
            .ForMember(dest => dest.Name, opt =>
                opt.MapFrom(src => src.Name));

        CreateMap<Category, CategoryDto>()
            .ReverseMap();
    }
}
