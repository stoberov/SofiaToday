namespace SofiaToday.Web.Controllers
{
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Services.Data.Contracts;
    using ViewModels.Messages;

    public class MessagesController : BaseController
    {
        private readonly IMessagesService messages;

        public MessagesController(IMessagesService messages)
        {
            this.messages = messages;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Index(CreateMessageInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                var message = this.Mapper.Map<Message>(model);

                this.messages.Add(message);

                this.TempData["Notification"] = GlobalConstants.MessageAddedSuccess;
                return this.Redirect("/");
            }

            return this.View(model);
        }
    }
}
