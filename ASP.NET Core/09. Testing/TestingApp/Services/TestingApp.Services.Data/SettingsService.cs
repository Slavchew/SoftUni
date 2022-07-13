namespace TestingApp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using TestingApp.Data.Common.Repositories;
    using TestingApp.Data.Models;
    using TestingApp.Services.Mapping;

    public class SettingsService : ISettingsService
    {
        private readonly IDeletableEntityRepository<Setting> settingsRepository;

        public SettingsService(IDeletableEntityRepository<Setting> settingsRepository)
        {
            this.settingsRepository = settingsRepository;
        }

        public int GetCount()
        {
            return this.settingsRepository.AllAsNoTracking().Count();
        }

        public Setting GetSettingByValue(string value)
        {
            return this.settingsRepository.AllAsNoTracking().FirstOrDefault(x => x.Value == value);
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.settingsRepository.All().To<T>().ToList();
        }
    }
}
