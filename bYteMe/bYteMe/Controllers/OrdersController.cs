namespace bYteMe.Controllers
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net.Mime;
    using System.Web.Mvc;

    [Authorize]
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
           const int DefaultCountOfOrders = 4;
           const int DefaultCountDislikes = 8;
           bYteMeDbContext db = new bYteMeDbContext();

           if (!db.Orders.Any())
           {
                var startDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string[] imagesPaths = new[]
                                           {
                                               startDirectory + "images\\orders\\beer.jpg",
                                               startDirectory + "images\\orders\\beers.jpg",
                                               startDirectory + "images\\orders\\rakia.jpg",
                                               startDirectory + "images\\orders\\alcohol-roulette.jpg"
                                           };
                string[] descriptions = new[]
                                            {
                                                "Отказали са ти няколко пъти? Започни с първата поръчка - една бира. Не се колебай, а поръчай веднага утешителната си награда!",
                                                "Положението започва да става сериозно. Трябва ти по-стабилна утеха. Поръчай безплатната си каса бира и да не ти пука за всички, които са те зарязали.",
                                                "Е, всяко зло за добро, нали? Нищо, че не ти се получава в любовта. За сметка на това може да се насладиш на домашна отлежала сливова ракия и то безплатно! Та нали ти вече си плати със сълзи и отчаяние.",
                                                "Брат, работата няма да стане, видяло се е. Може би свалките не са за теб. Ти достигна до последното ниво на утешителните награди. Събери аверите и се почерпете. Друг вариант вече не ти остана."
                                            };


                for (int i = 1; i <= DefaultCountOfOrders; i++)
                {
                    Order order = new Order();
                    order.OrderId = i;
                    Image img = Image.FromFile(imagesPaths[i - 1]);
                    byte[] arr;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        arr = ms.ToArray();
                    }

                    order.Photo = arr;
                    order.Description = descriptions[i - 1];

                    int dislikes = DefaultCountDislikes * i * i;
                    order.RequiredDislikes = DefaultCountDislikes * i;
                    db.Orders.Add(order);
                }

                db.SaveChanges();
            }

            return this.View(db.Orders);
        }
    }
}