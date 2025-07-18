using Microsoft.Extensions.Logging;
using Vitura.API.Repositories;
using Vitura.API.Tests.Mock.Models;

namespace Vitura.API.Tests;

public class BaseRepositoryTest
{
    [Fact]
    public void TestGetAll()
    {
        var logger = new LoggerFactory().CreateLogger<BaseRepository<MockModel>>();
        var baseRepository = new BaseRepository<MockModel>(logger, "mockdata.json");
        
        var characters = baseRepository.GetAll();
        
        Assert.NotNull(characters);
        Assert.NotEmpty(characters);
        
        for (var i = 0; i < characters.Count; i++)
        {
            var expectedId = i + 1;
            Assert.Equal(characters[i].Id, expectedId);
        }
    }
    
    [Fact]
    public void TestGetById()
    {
        var logger = new LoggerFactory().CreateLogger<BaseRepository<MockModel>>();
        var baseRepository = new BaseRepository<MockModel>(logger, "mockdata.json");
        
        var esquieId = 8;
        var esquieName = "Esquie";
        var esquie = baseRepository.GetById(esquieId);
        
        Assert.NotNull(esquie);
        Assert.Equal(esquie.Id, esquieId);
        Assert.Equal(esquie.Name, esquieName);
    }

    [Fact]
    public void TestCreateModel()
    {
        var logger = new LoggerFactory().CreateLogger<BaseRepository<MockModel>>();
        var baseRepository = new BaseRepository<MockModel>(logger, "mockdata.json");
        var name = "Francios";
        var expectedId = 9;
        var character = new MockModel { Name = name };
        
        var created = baseRepository.Create(character);
        Assert.NotNull(created);
        Assert.Equal(created.Name, name);
        Assert.Equal(created.Id, expectedId);
    }
}