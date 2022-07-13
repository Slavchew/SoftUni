namespace TestingApp.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Moq;

    using TestingApp.Data;
    using TestingApp.Data.Common.Repositories;
    using TestingApp.Data.Models;
    using TestingApp.Data.Repositories;

    using Xunit;

    public class SettingsServiceTests
    {
        [Fact]
        public void GetCountShouldReturnCorrectNumber()
        {
            var repository = new Mock<IDeletableEntityRepository<Setting>>();
            repository.Setup(x => x.AllAsNoTracking()).Returns(new List<Setting>
                {
                    new Setting(),
                    new Setting(),
                    new Setting(),
                }.AsQueryable());

            var service = new SettingsService(repository.Object);
            Assert.Equal(3, service.GetCount());
            repository.Verify(x => x.AllAsNoTracking(), Times.Once);
        }

        [Fact]
        public async Task GetCountShouldReturnCorrectNumberUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "SettingsTestDb").Options;
            using var dbContext = new ApplicationDbContext(options);
            dbContext.Settings.Add(new Setting());
            dbContext.Settings.Add(new Setting());
            dbContext.Settings.Add(new Setting());
            await dbContext.SaveChangesAsync();

            using var repository = new EfDeletableEntityRepository<Setting>(dbContext);
            var service = new SettingsService(repository);
            Assert.Equal(3, service.GetCount());
        }

        [Fact]
        public void GetSettingByValueShouldReturnSettingIfSettingWithThisValueExists()
        {
            var repo = new Mock<IDeletableEntityRepository<Setting>>();
            repo.Setup(x => x.AllAsNoTracking()).Returns(new List<Setting>
            {
                new Setting { Name = "Sett1", Value = "Sett1" },
                new Setting { Name = "Sett2", Value = "Sett2" },
                new Setting { Name = "Sett4", Value = "Sett4" },
            }.AsQueryable());

            var service = new SettingsService(repo.Object);

            var expectedSetting = new Setting { Name = "Sett4", Value = "Sett4" };

            Assert.Equal(expectedSetting.Name, service.GetSettingByValue("Sett4").Name);
            Assert.Equal(expectedSetting.Value, service.GetSettingByValue("Sett4").Value);
        }

        [Fact]
        public void GetSettingByValueShouldReturnNullIfSettingWithThisValueNotExists()
        {
            var repo = new Mock<IDeletableEntityRepository<Setting>>();
            repo.Setup(x => x.AllAsNoTracking()).Returns(new List<Setting>
            {
                new Setting { Name = "Sett1", Value = "Sett1" },
                new Setting { Name = "Sett2", Value = "Sett2" },
                new Setting { Name = "Sett4", Value = "Sett4" },
            }.AsQueryable());

            var service = new SettingsService(repo.Object);

            Assert.Null(service.GetSettingByValue("Sett3"));
        }

        [Fact]
        public async Task GetSettingByValueShouldReturnSettingIfSettingWithThisValueExistsUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("test").Options;

            using var dbContext = new ApplicationDbContext(options);
            await dbContext.Settings.AddAsync(new Setting { Name = "Sett1", Value = "Sett1" });
            await dbContext.Settings.AddAsync(new Setting { Name = "Sett2", Value = "Sett2" });
            await dbContext.Settings.AddAsync(new Setting { Name = "Sett4", Value = "Sett4" });
            await dbContext.SaveChangesAsync();

            using var repo = new EfDeletableEntityRepository<Setting>(dbContext);
            var service = new SettingsService(repo);

            var expectedSetting = new Setting { Name = "Sett4", Value = "Sett4" };

            Assert.Equal(expectedSetting.Name, service.GetSettingByValue("Sett4").Name);
            Assert.Equal(expectedSetting.Value, service.GetSettingByValue("Sett4").Value);
        }

        [Fact]
        public async Task GetSettingByValueShouldReturnNullIfSettingWithThisValueNotExistsUsingDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("test").Options;

            using var dbContext = new ApplicationDbContext(options);
            await dbContext.Settings.AddAsync(new Setting { Name = "Sett1", Value = "Sett1" });
            await dbContext.Settings.AddAsync(new Setting { Name = "Sett2", Value = "Sett2" });
            await dbContext.Settings.AddAsync(new Setting { Name = "Sett4", Value = "Sett4" });
            await dbContext.SaveChangesAsync();

            using var repo = new EfDeletableEntityRepository<Setting>(dbContext);
            var service = new SettingsService(repo);

            var expectedSetting = new Setting { Name = "Sett4", Value = "Sett4" };

            Assert.Null(service.GetSettingByValue("Sett3"));
        }
    }
}
