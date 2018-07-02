using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UFSTestApplication.Models
{
    public class PassengerDbInitializer : DropCreateDatabaseAlways<PassengerContext>
    {
        protected override void Seed(PassengerContext db)
        {
            db.Passengers.Add(new Passenger {Name = "Иванов Иван Иванович", DateofBirth = DateTime.Now.AddYears(-15), PassengerType = 2 });
            db.Passengers.Add(new Passenger { Name = "Петров Петр Петрович", DateofBirth = DateTime.Now.AddYears(-7), PassengerType = 1 });
            db.Passengers.Add(new Passenger { Name = "Сидоров Сергей Сергеевич", DateofBirth = DateTime.Now.AddYears(-4), PassengerType = 0 });
            base.Seed(db);
        }

    }
}