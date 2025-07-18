using System.Text.Json;
using Vitura.API.Models;
using Vitura.API.Repositories.Interfaces;

namespace Vitura.API.Repositories;

public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseModel
{
    // Left as protected in case access required form inheriting class.
    protected List<TModel> _data;

    private int _lastIndex;

    private readonly ILogger _logger;
    
    public BaseRepository(ILogger logger, string fileName)
    {
        _logger = logger;

        try
        {
            using (var sr = new StreamReader($"Data\\{fileName}"))
            {
                var json = sr.ReadToEnd();

                var data = JsonSerializer.Deserialize<List<TModel>>(json);

                if (data == null)
                {
                    _logger.LogError("No data found.");
                    return;
                }

                _data = data;

                var lastPrescription = _data.Last();
                _lastIndex = lastPrescription.Id + 1;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
    }

    public List<TModel>? GetAll()
    {
        try
        {
            return _data;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public List<TModel>? GetAll(Predicate<TModel> predicate)
    {
        try
        {
            return _data.FindAll(predicate);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

    public TModel? GetById(int id)
    {
        try
        {
            return _data.First(model => model.Id == id);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }
    
    public TModel? Create(TModel model)
    {
        try
        {
            model.Id = _lastIndex;
            _lastIndex++;

            _data.Add(model);
            return model;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return null;
        }
    }

}