namespace SofiaToday.Services.Data
{
    using System.Linq;

    using SofiaToday.Data.Models;

    public interface IJokesService
    {
        IQueryable<Joke> GetRandomJokes(int count);

        Joke GetById(string id);
    }
}
