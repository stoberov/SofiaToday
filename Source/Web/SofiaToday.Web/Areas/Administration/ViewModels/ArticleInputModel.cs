namespace SofiaToday.Web.Areas.Administration.ViewModels
{
    using System.Web.Mvc;

    public class ArticleInputModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        [AllowHtml]
        public string Content { get; set; }
    }
}
