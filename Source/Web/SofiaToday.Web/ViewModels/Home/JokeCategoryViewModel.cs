namespace SofiaToday.Web.ViewModels.Home
{
    using SofiaToday.Data.Models;
    using SofiaToday.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel : IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
