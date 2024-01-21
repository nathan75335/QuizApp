using AutoMapper;
using Microsoft.Extensions.Logging;
using QuizMaster.BusinessLogic.Exceptions;
using QuizMaster.BusinessLogic.Profiles.DTOs;
using QuizMaster.BusinessLogic.Requests;
using QuizMaster.BusinessLogic.Services.Interfaces;
using QuizMaster.DataAccess.Entities;
using QuizMaster.DataAccess.Repositories.Interfaces;

namespace QuizMaster.BusinessLogic.Services.Implementations;

public class AnswerOptionService : IAnswerOptionService
{
    private readonly IAnswerOptionRepository _answerOptionRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<AnswerOptionService> _logger;

    public AnswerOptionService(IAnswerOptionRepository answerOptionRepository,
        IMapper mapper, ILogger<AnswerOptionService> logger)
    {
        _answerOptionRepository = answerOptionRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<AnswerOptionsDto> AddAnswerOptionAsync(AnswerOptionRequest optionRequest)
    {
        var option = await _answerOptionRepository
            .AddAnswerOptionAsync(_mapper.Map<AnswerOption>(optionRequest));

        return _mapper.Map<AnswerOptionsDto>(option);
    }

    public async Task<AnswerOptionsDto> DeleteAnswerOptionAsync(AnswerOption optionRequest)
    {
        var option = await _answerOptionRepository.GetAnswerOptionByIdAsync(optionRequest.OptionId);
        if (option is null)
        {
            _logger.LogError("There is not any option with that id");
            throw new NotFoundException("There is not any option with such an id");
        }

        var optionDeleted = await _answerOptionRepository.DeleteAnswerOptionAsync(option);

        return _mapper.Map<AnswerOptionsDto>(optionDeleted);
    }

    public async Task<List<AnswerOptionsDto>> GetOptionsByQuestionIdAsync(int questionId)
    {
        var options = await _answerOptionRepository.GetOptionsByQuestionIdAsync(questionId);

        return _mapper.Map<List<AnswerOptionsDto>>(options);
    }

    public async Task<AnswerOptionsDto> UpdateAnswerOption(AnswerOptionRequest answerOptionRequest)
    {
        var option = await _answerOptionRepository.GetAnswerOptionByIdAsync(answerOptionRequest.Id);
        if (option is null)
        {
            _logger.LogError("There is no any option to update with that id");
            throw new NotFoundException("There is not any option to update with such an id");
        }

        _mapper.Map(answerOptionRequest, option);
        var optionUpdated = await _answerOptionRepository.UpdateAnswerOptionAsync(option);

        return _mapper.Map<AnswerOptionsDto>(optionUpdated);
    }
}
