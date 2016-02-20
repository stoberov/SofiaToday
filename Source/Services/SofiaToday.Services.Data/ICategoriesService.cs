namespace SofiaToday.Services.Data
{
    using System.Linq;

    using SofiaToday.Data.Models;

    public interface ICategoriesService
    {
        IQueryable<JokeCategory> GetAll();

        JokeCategory EnsureCategory(string name);
    }
}
