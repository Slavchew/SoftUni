namespace TestingApp.Services.Data
{
    using System.Collections.Generic;

    using TestingApp.Data.Models;

    public interface ISettingsService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        Setting GetSettingByValue(string value);
    }
}
