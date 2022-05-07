using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Content;

public class AssignmentService : ServiceBase<Assignment, AssignmentDto>, IAssignmentService
{
    private readonly IAssignmentRepository _repository;
    private readonly IMapper _mapper;

    public AssignmentService(IAssignmentRepository repository, IMapper mapper) : base(repository, mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    protected override void UpdateEntityValues(Assignment entity, AssignmentDto entityDto)
    {
        entity.Author = entityDto.Author;
        entity.CategoryId = entityDto.CategoryId;
        entity.Title = entityDto.Title;
        entity.Description = entityDto.Description;
    }

    public async Task<List<AssignmentDto>> FindAssignmentsWithCategoriesAndSections()
    {
        var assignments = await _repository.FindAssignmentsWithCategoriesAndSections();
        return _mapper.Map<List<AssignmentDto>>(assignments);
    }
}