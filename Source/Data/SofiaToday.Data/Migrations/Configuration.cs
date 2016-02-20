namespace SofiaToday.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SofiaToday.Common;
    using SofiaToday.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            SeedAdmin(context);
            SeedEvents(context);
        }

        private static void SeedAdmin(ApplicationDbContext context)
        {
            const string AdministratorUserName = "admin@admin.com";
            const string AdministratorPassword = AdministratorUserName;

            if (!context.Roles.Any())
            {
                // Create admin role
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRoleName };
                roleManager.Create(role);

                // Create admin user
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = AdministratorUserName, Email = AdministratorUserName };
                userManager.Create(user, AdministratorPassword);

                // Assign user to admin role
                userManager.AddToRole(user.Id, GlobalConstants.AdministratorRoleName);
            }
        }

        private static void SeedEvents(ApplicationDbContext context)
        {
            if (!context.Events.Any())
            {
                context.Events.Add(new Event
                {
                    Title = "Bulgaria Web Summit 2016",
                    Description = @"An event about (almost) everything a modern web person should know.
Bulgaria Web Summit is an annual conference about the modern web.
Benefit: Practical lessons which you can immediately apply in your work and thus gain time and money.The attendance fee is actually an investment.An investment in yourselves.
Community: A balanced mixture of participants and speakers working in programming,
                    design,
                    marketing and business development.Find partners,
                    colleagues or ideas to develop.
Party!In addition to the event we are planning a great party and other surprises for you.You should treat yourselves to an amazing weekend in Sofia!",
                    Location = "Inter Expo Center",
                    StartDateTime = DateTime.Now.AddDays(5).AddHours(2),
                    EndDateTime = DateTime.Now.AddDays(5).AddHours(6),
                    Category = Category.Misc,
                    Price = 0,
                    ImageUrl = "https://scontent-fra3-1.xx.fbcdn.net/hphotos-xap1/t31.0-8/1933225_765211740279327_6705588417316476162_o.jpg"
                });

                context.Events.Add(new Event
                {
                    Title = "Mihaela Fileva, Preyah & Divna LIVE - club *MIXTAPE 5* | 26.02",
                    Description = @"Серията ""тройни"" лайв формати на club *MIXTAPE 5* продължава с пълна сила, този път с участието на Mihaela Fileva, Preyah и Дивна.
След безупречния успех на предишните ""ladies"" събития сме жадни да чуем още три успешни и талантливи изпълнителки.Този път те са част от лейбъла Monte Music Ltd.и ще излязат за първи път заедно на сцената в голямата зала на ""Mixtape 5"" на 26 февруари 2016 г.",
                    Location = "Mixtape 5",
                    StartDateTime = DateTime.Now.AddDays(2).AddHours(1),
                    EndDateTime = DateTime.Now.AddDays(2).AddHours(3),
                    Category = Category.Nightlife,
                    Price = 10,
                    ImageUrl = "https://scontent-fra3-1.xx.fbcdn.net/hphotos-xal1/t31.0-8/12513665_1065439380153133_6283512421692433897_o.jpg"
                });

                context.Events.Add(new Event
                {
                    Title = "Премиера , Официално! Под прикритие - Сезон 5",
                    Description = @"The new season starts now!",
                    Location = "BNT 1",
                    StartDateTime = DateTime.Now.AddDays(15).AddHours(12),
                    EndDateTime = DateTime.Now.AddDays(15).AddHours(16),
                    Category = Category.Cinema,
                    Price = 0,
                    ImageUrl = "http://www.chudesa.net/wp-content/uploads/2013/02/pod_prikritie.jpg"
                });

                context.SaveChanges();
            }
        }
    }
}
