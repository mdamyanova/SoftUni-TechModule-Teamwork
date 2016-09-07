namespace bYteMe.Controllers
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;
    using bYteMe.Constants;
    using bYteMe.Models;

    //[Authorize]
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
            const int DefaultCountOfOrders = 4;
            const int DefaultCountDislikes = 8;
            var db = new bYteMeDbContext();
            if (!db.Orders.Any())
            {
                var startDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string[] imagesPaths =
                    {
                       startDirectory + "images\\orders\\beer.jpg",
                       startDirectory + "images\\orders\\beers.jpg",
                       startDirectory + "images\\orders\\rakia.jpg",
                       startDirectory + "images\\orders\\alcohol-roulette.jpg"
                   };
                var descriptions = TextConstants.OrdersDescriptions;

                for (var i = 1; i <= DefaultCountOfOrders; i++)
                {
                    var order = new Order { OrderId = i };
                    var img = Image.FromFile(imagesPaths[i - 1]);
                    byte[] arr;
                    using (var ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        arr = ms.ToArray();
                    }

                    order.Photo = arr;
                    order.Description = descriptions[i - 1];

                    var dislikes = DefaultCountDislikes * i * i;
                    order.RequiredDislikes = dislikes * i;
                    db.Orders.Add(order);
                }

                db.SaveChanges();
            }

            return this.View(db.Orders);
        }

        public ActionResult Order()
        {
            return this.View();
        }
    }
}