using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UFSTestApplication.Models;
using static UFSTestApplication.Models.PassengerViewModel;

namespace UFSTestApplication.Controllers
{
    public class PassengersController : Controller
    {
        private PassengerContext db = new PassengerContext();

        //[Route()]
        // GET: Passengers
        public async Task<ActionResult> Index()
        {
            var passengersList = await db.Passengers.ToListAsync();
            return View(passengersList.Select(_ => new PassengerViewModel(_)));
        }

        // GET: Passengers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = await db.Passengers.FindAsync(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(new PassengerViewModel(passenger));
        }

        // GET: Passengers/Create
        public ActionResult Create()
        {
            var model = new PassengerViewModel();
            //model.PassengerTypes = new SelectList(Enum.GetValues(typeof(PassengerTypesEnum)));
            model.PassengerTypes = GetPassengerTypeList();
            return View(model);
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PassengerViewModel passenger)
        {
            passenger.PassengerTypes = GetPassengerTypeList(); // нет, серьезно?! он просто сбрасывал модель при валидации
            if (ModelState.IsValid)
            {
                db.Passengers.Add(passenger);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(passenger);
        }

        // GET: Passengers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = await db.Passengers.FindAsync(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            var model = new PassengerViewModel(passenger);
            //model.PassengerTypes = new SelectList(Enum.GetValues(typeof(PassengerTypesEnum)));//не работает
            model.PassengerTypes = GetPassengerTypeList();
            return View(model);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,DateofBirth,PassengerType")] PassengerViewModel passenger)
        {

            passenger.PassengerTypes = GetPassengerTypeList(); // нет, серьезно?! он просто сбрасывал модель при валидации
            if (ModelState.IsValid)
            {
                db.Entry(passenger).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(passenger);
        }

        // GET: Passengers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = await db.Passengers.FindAsync(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Passenger passenger = await db.Passengers.FindAsync(id);
            db.Passengers.Remove(passenger);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // костыль, чтобы не падать при валидации
        private List<SelectListItem> GetPassengerTypeList()
        {
            return new List<SelectListItem>
             {
                 new SelectListItem
                 {
                     Text = "Взрослый",
                     Value = "2"
                 },
                 new SelectListItem
                 {
                     Text = "Ребенок",
                     Value = "1"
                 },
                 new SelectListItem
                 {
                     Text = "Младенец",
                     Value = "0"
                 }
            };
        }
    }
}
