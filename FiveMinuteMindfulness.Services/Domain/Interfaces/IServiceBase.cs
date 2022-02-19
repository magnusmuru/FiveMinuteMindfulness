namespace FiveMinuteMindfulness.Services.Domain.Interfaces;

public interface IServiceBase<TEntityDto>
    where TEntityDto : class
{
    Task<TEntityDto> GetByIdAsync(Guid id);
    Task<List<TEntityDto>> GetAllAsync();
    Task<TEntityDto> AddAsync(TEntityDto entityDto);
    Task<bool> RemoveAsync(Guid id);
    Task<TEntityDto> UpdateAsync(TEntityDto entityDto);
}