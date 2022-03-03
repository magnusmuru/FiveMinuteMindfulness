using AutoMapper;
using FiveMinuteMindfulness.Core.Dto.Content;
using FiveMinuteMindfulness.Core.Models.Content;
using FiveMinuteMindfulness.Data.Repositories.Content.Interfaces;
using FiveMinuteMindfulness.Services.Content.Interfaces;
using FiveMinuteMindfulness.Services.Domain;

namespace FiveMinuteMindfulness.Services.Content;

public class AssignmentService : ServiceBase<Assignment, AssignmentDto>, IAssignmentService
{
    public AssignmentService(IAssignmentRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    protected override void UpdateEntityValues(Assignment entity, AssignmentDto entityDto)
    {
        throw new NotImplementedException();
    }
}