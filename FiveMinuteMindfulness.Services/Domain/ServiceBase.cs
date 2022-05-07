using AutoMapper;
using FiveMinuteMindfulness.Core.Constant;
using FiveMinuteMindfulness.Core.Domain.Interfaces;
using FiveMinuteMindfulness.Core.Dto;
using FiveMinuteMindfulness.Data.Repositories.Interfaces;
using FiveMinuteMindfulness.Services.Domain.Interfaces;

namespace FiveMinuteMindfulness.Services.Domain;

public abstract class ServiceBase<TEntity, TEntityDto> : IServiceBase<TEntityDto>
    where TEntity : class, IEntityWithId
    where TEntityDto : BaseDto
{
    private readonly IMapper _mapper;
    private readonly IRepositoryBase<TEntity> _repository;

    protected ServiceBase(
        IRepositoryBase<TEntity> repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public virtual async Task<TEntityDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.Find(id);
        return entity == null ? null : _mapper.Map<TEntityDto>(entity);
    }

    public virtual async Task<List<TEntityDto>> GetAllAsync()
    {
        var entities = await _repository.FindAll();
        return _mapper.Map<List<TEntityDto>>(entities);
    }

    public async Task<TEntityDto> AddAsync(TEntityDto entityDto)
    {
        entityDto.Id = Guid.NewGuid();

        if (entityDto.CreatedBy == Guid.Empty)
        {
            entityDto.CreatedBy = new Guid(UserConstant.SystemUserId);
            entityDto.UpdatedBy = new Guid(UserConstant.SystemUserId);
        }

        var entity = _mapper.Map<TEntity>(entityDto);

        await _repository.Add(entity);

        return _mapper.Map<TEntityDto>(entity);
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        var entity = await _repository.Find(id);

        if (entity == null)
        {
            return false;
        }

        await _repository.Remove(entity);
        return true;
    }

    public async Task<TEntityDto?> UpdateAsync(TEntityDto entityDto)
    {
        var entity = await _repository.Find(entityDto.Id);

        if (entity == null)
        {
            return null;
        }

        UpdateEntityValues(entity, entityDto);
        await _repository.Update(entity);

        return _mapper.Map<TEntityDto>(entity);
    }

    protected abstract void UpdateEntityValues(TEntity entity, TEntityDto entityDto);
}