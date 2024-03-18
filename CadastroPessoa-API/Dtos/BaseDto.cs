namespace CadastroPessoa_API.Dtos
{
    public abstract class BaseDto<TEntity, TDto>
    {
        public abstract List<TDto> GetListInstance(List<TEntity> list);

        public abstract TDto GetInstance(TEntity entity);
    }
}
