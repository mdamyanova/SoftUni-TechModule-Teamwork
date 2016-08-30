namespace bYteMe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web.UI.WebControls;

    using bYteMe.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.bYteMeDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "bYteMe.Models.bYteMeDbContext";
        }

        protected override void Seed(Models.bYteMeDbContext context)
        {
            if (!context.Users.Any())
            {
                // if the database is empty, populate sample data in it
                for (int i = 0; i < 10; i++)
                {
                    var userName = bYteMe.Constants.TextConstants.UserNames[i];
                    var fullName = bYteMe.Constants.TextConstants.FullNames[i];
                    var biography = bYteMe.Constants.TextConstants.Biographies[i];
                    var email = userName + "@bYteMeMail.com";
                    var password = "123";
                    this.CreateUser(context, userName, fullName, biography, email, password, 10, 8);
                }

                this.CreatePost(
                    context,
                    "gosho",
                    "Rakia",
                    " is the traditional drink of Bulgaria. It is a clear alcoholic beverage made by the distillation of fermented fruit. It has a high alcohol content "
                    + "varying anywhere between 40% and 95% alc. (80 to 190 proof), making it a potent drink. There are different types of rakia, all depending on what fruit it is"
                    + " made of (grapes, plums, apricots, pears, apples, cherries, figs, quinces). In Bulgaria, rakia made from grapes (like Italian grappa) is the most popular, "
                    + "but slivovitza (rakia made from plums) is also popular. Making rakia at home has been a part of Bulgarian traditions for centuries (scroll down for a recipe). "
                    + "Nowadays more and more of the produce is being commercially produced in distilleries.\r\n\r\nThe authentic Bulgarian rakias (or grappas) have a highly distinctive "
                    + "flavor and a deep and smooth taste. They are produced according to age old local traditions. Rakia is most commonly made from grapes and is a limpid, crystal-clear "
                    + "liquid with an intense aroma and the fine unmistakable flavor of the grape (Muscat, Cabernet, Gewurztraminer, Chardonnay, etc) it is made from. Colors and taste can vary – "
                    + "the color of rakia could vary from liquid clear to golden salmon and the taste could vary from distinctively grape-tasting to vanilla and toasted nut flavors, with powdered sugar and pepper fade nuances.");
                this.CreatePost(
                    context,
                    "grape",
                    "Bulgarian wine",
                    "Grape growing and wine production have a long history in Bulgaria, dating back to the times of the Thracians. Wine is, together with beer and grape rakia, among the most popular alcoholic beverages in the country.\r\n\r\nBulgaria"
                    + " was the world\'s second largest wine producer in 1980s, but the industry declined after the collapse of communism.[1][2] Wine production is growing again, reaching 108m litres in 2011, an increase of 4.9% from the previous year.");
                this.CreatePost(
                    context,
                    "ouzo134",
                    "Ouzo History",
                    "Ouzo has its roots in tsipouro, which is said to have been the work of a group of 14th-century monks on Mount Athos. One version of it was flavoured with anise. This version eventually came to be called ouzo. Modern ouzo "
                    + "distillation largely took off in the beginning of the 19th century following Greek independence. The first ouzo distillery was founded in Tyrnavos in 1856 by Nikolaos Katsaros, giving birth to the famous ouzo Tyrnavou. When "
                    + "absinthe fell into disfavour in the early 20th century, ouzo was one of the products whose popularity rose to fill the gap; it was once called \"a substitute for absinthe without the wormwood\".");
                this.CreatePost(
                    context,
                    "gosho",
                    "Meaning of name Georgi",
                    "Georgi   is a radiant and influential man (master number 11), who possesses an imposing, authoritarian and masculine character although he remains essentially warm, friendly and generous. He tends to takes great care of his "
                    + "appearance which could come across as a sort of vanity, or he may use his verbal talents for the purpose of seduction... Open-minded, communicative and inquisitive, he is interested in everything and loves sharing the"
                    + " knowledge that he acquires with others, which he does more or less cheerfully... He often conceals his extreme sensitivity behind a rather blunt and abrupt manner. He is honest, loyal and anything but lazy while he "
                    + "loathes pretense, flattery and deceit. Georgi   is capable of tremendous generosity and is always ready to help if he can. He seeks power and this endows him with formidable energy, determination and courage although he"
                    + " lacks tolerance for those who are less clever than he is and is even capable of bad faith at times, while he can certainly be quite argumentative. He is prone to experiencing high levels of emotional tension - "
                    + "often to the detriment of his internal equilibrium. Of course, the inherent risks of his master number are all sorts of excess: too much kindness or humility - and their opposites: megalomania, tyranny, abuse of power "
                    + "and Machiavellianism... As a child, he is brave and determined and already knows exactly what he wants. A conflict of authority could arise from an upbringing that is too lax or interfering, but his parents can rest assured, "
                    + "he is somebody who can be trusted.");
                this.CreatePost(
                    context,
                    "sasheto0o",
                    "The 10 Things That Happen When You Fall In Love with a Programmer",
                    "There are many days where your conversations need an interpreter. He speaks in code, he thinks in code, "
                    + "he rambles in code. You very quickly learn the importance of the *smile and nod*.\r\nHis code talk rubs off on you. "
                    + "You start to think in code. You spend your evening over dinner discussing what a “problem” is and how to “define solutions.”"
                    + " You stop asking yourself if this is normal.\r\nYour house will become more tech-y than you have any conscious need for. "
                    + "You’ll come home one day and hear these words, “I set up our own cloud server today!” Uhh… what for? “Come on! "
                    + "Check this out! Be excited!” True story. (Note from Marcel: I actually said I set up our ownCloud server today)\r\nSeparating from Technology is difficult. H"
                    + "is newspaper is not the old fashion kind that you hold in your hand and read over coffee. When the alarm goes off at 0600, he’s reading Pulse news. All day long,"
                    + " there’s some sort of electronic attached to his hand. In rebellious defiance, you are deciding to keep your"
                    + " children away from technology as long as possible.\r\nYou have more computers, laptops, USB cables and other cables than you need. If you can’t find something,"
                    + " you have to wait until you can ask him where he hid it. It’s frequently hiding in all of the other cables. "
                    + "Never mind trying to look for it.\r\nHe has to have his own office. Really, it’s a room for the computers and cables. He’s never in there (because laptops m"
                    + "ove downstairs…) but he really really has to have that room.\r\nYou have to become an early adopter. For those of you without business backgrounds, "
                    + "this is the thing that makes you purchase the coolest, newest, most “necessary” piece of technology that will make your life better before everyone else gets the hint that t"
                    + "hey need it. You had it first. He has a Pebble watch. I have a Moto 360. I’m not sure my life is more fulfilled.\r\nYou have to draw the line at hi-tech huskies. There’s no reason that "
                    + "huskies should be hi-tech.\r\nYou’ll also learn to think in lists (see what happened here?). You’ll think things like “what are the ten things that happen when you fall in love with a programmer….”\r\nTher"
                    + "e will never be a dull moment in the house. Techies are quirky – in the best way possible. They are amazing, intelligent, creative and always pushing for the next best thing. Your life will change in a good way. You’ll be challenged, learn new things, and hopefully have a bright future together.");
                context.SaveChanges();
            }
        }
     
        private void CreateUser(bYteMeDbContext context, string userName, string fullName, string biography, string email, string password, int likes, int dislikes)
        {
           var userManager = new UserManager<User>(new UserStore<User>(context));
            userManager.PasswordValidator = new PasswordValidator()
                                                {
                                                    RequiredLength = 3,
                                                    RequireNonLetterOrDigit = false,
                                                    RequireDigit = false,
                                                    RequireLowercase = false,
                                                    RequireUppercase = false
                                                };
            var startDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] imagesPaths = new[]
                                       {
                                           "classy_dev", "desperate_wife", "gosho", "grape", "hacker", "ouzo134",
                                           "sasheto0o"
                                       };
            string path = startDirectory + "/images/default-profile-picture.jpg";

            if (imagesPaths.Any(n => n == userName))
            {
                path = startDirectory + "/images/profiles/" + imagesPaths.First(u => u == userName) + ".jpg";
               
            }

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            var image = br.ReadBytes((int)fs.Length);

            br.Close();
            fs.Close();
            var user = new User
                           {
                               UserName = userName,
                               FullName = fullName,
                               Biography = biography,
                               Email = email,
                               Password = password,
                               Likes = likes,
                               Dislikes = dislikes,
                               ProfilePhoto = image
                           };
            var userCreateResult = userManager.Create(user, password);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }
        }

        private void CreatePost(bYteMeDbContext context, string username, string title, string body)
        {
            var post = new Post
                           {
                               AuthorId = context.Users.FirstOrDefault(u => u.UserName == username)?.Id,
                               Title = title,
                               Body = body
                           };

            context.Posts.Add(post);
        }
    }
}
