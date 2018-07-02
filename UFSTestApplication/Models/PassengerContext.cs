using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UFSTestApplication.Models
{
    public class PassengerContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; }
    }
}