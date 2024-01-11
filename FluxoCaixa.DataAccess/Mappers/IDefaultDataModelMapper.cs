namespace FluxoCaixa.DataAccess.Mappers
{
    public interface IDefaultDataModelMapper<TModel, TEntity>
    {
        TModel ToModel(TEntity entity);
        TEntity ToEntity(TModel model);
    }
}
