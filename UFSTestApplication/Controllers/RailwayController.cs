//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web.Mvc;
//using UFSTestApplication.Models;

//namespace UFSTestApplication.Controllers
//{
//    public class RailwayController : Controller
//    {

//        PassengerContext db = new PassengerContext();

//        public ActionResult passengers()
//        {

//            IEnumerable<Passenger> passengers = db.Passengers;
//            ViewBag.Passengers = passengers;
//            return View();
//        }

//        [HttpGet]
//        public ActionResult Info(int? id)
//        {
//            if (!id.HasValue)
//            {
//                return HttpNotFound();
//            }
//            Passenger requestedPassenger = db.Passengers.FirstOrDefault(_ => _.Id == id.Value);
//            if (requestedPassenger == null)
//            {
//                return HttpNotFound();
//            }

//            SelectList PassengerTypes = new SelectList(Enum.GetValues(typeof(PassengerTypes)));
            
//            if (requestedPassenger != null)
//            {
//                PassengerTypes = new SelectList(Enum.GetValues(typeof(PassengerTypes)), requestedPassenger.PassengerType);
//            }
//            else
//            {
                
//            }
//            ViewBag.PasangerTypeList = PassengerTypes;
//            ViewBag.Title = "Редактирование данных о пассажире";
//            return View(requestedPassenger);
//        }

//        [HttpPost]
//        public ActionResult Info(Passenger passenger)
//        {
//            if (ModelState.IsValid)
//            {
//                Passenger oldPassenger = db.Passengers.Find(passenger.Id);
//                if (oldPassenger != null)
//                {
//                    db.Passengers.Remove(oldPassenger);
//                }
//                db.Passengers.Add(passenger);
//                db.SaveChanges();
//                //return oldPassenger == null ? "Добавление пассажира успешно!" : "Обновление пассажира успешно!";
//            }
//            else
//            {
//                }
//            return View();
//        }
//    }
//}