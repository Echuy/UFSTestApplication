using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UFSTestApplication.Validation;
using static UFSTestApplication.Models.PassengerViewModel;

namespace UFSTestApplication.Models
{
    [AgeValidation(ErrorMessage = "Возраст не соответствует типу пассажира")]
    public class PassengerViewModel : Passenger//, IValidatableObject
    {
        public PassengerViewModel(Passenger passenger)
        {
            Id = passenger.Id;
            DateofBirth = passenger.DateofBirth;
            Name = passenger.Name;
            PassengerType = passenger.PassengerType;
        }
        public PassengerViewModel()
        {

        }
        [NotMapped]
        public IEnumerable<SelectListItem> PassengerTypes { get; set; }
        [NotMapped]
        public string PassengerTypeValue
        {
            get
            {
                return Enum.GetName(typeof(PassengerTypesEnum),PassengerType);
            }
            set
            {
                PassengerType = int.Parse(value);
            }
        }
        /*
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            var today = DateTime.Today;
            var age = today.Year - this.DateofBirth.Year;

            switch (this.PassengerType)
            {
                case 0:
                    if (age >= 5) { errors.Add(new ValidationResult("Младенцем считается пассажир до 5 лет")); }
                    break;
                case 1:
                    if (age < 5 || age >= 10) { errors.Add(new ValidationResult("Ребенком считается пассажир от 5 до 10 лет")); }
                    break;
                case 2:
                    if (age < 10) { errors.Add(new ValidationResult("Взрослым считается пассажир от 10 лет")); }
                    break;
                default:
                    break;
            }

            return errors;
        }*/

        public enum PassengerTypesEnum { Младенец, Ребенок, Взрослый };
    }
}