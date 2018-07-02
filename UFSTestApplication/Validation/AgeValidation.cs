using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using UFSTestApplication.Models;

namespace UFSTestApplication.Validation
{
    public class AgeValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            PassengerViewModel pass = value as PassengerViewModel;

            var today = DateTime.Today;
            var age = today.Year - pass.DateofBirth.Year;

            switch (pass.PassengerType)
            {
                case 0:
                    if (age >= 5) { return false; };
                    break;
                case 1:
                    if (age < 5 || age >= 10) { return false; };
                    break;
                case 2:
                    if (age < 10) { { return false; } }
                    break;
            }
            return true;
        }
    }
}