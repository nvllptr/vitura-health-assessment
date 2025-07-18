namespace Vitura.API.Repositories.Interfaces;

public interface IBaseRepository<TModel> where TModel : class
{
    public List<TModel>? GetAll();

    public List<TModel>? GetAll(Predicate<TModel> predicate);
    public TModel? GetById(int id);

    public TModel? Create(TModel model);
}