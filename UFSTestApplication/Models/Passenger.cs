using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UFSTestApplication.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        [RegularExpression(@"[а-яА-Я ]+$", ErrorMessage = "Может состоять только из символов русского алфавита")]

        [Display(Name = "ФИО")]
        public String Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime DateofBirth { get; set; }

        [Display(Name = "Тип пассажира")]
        //ToDo тип пассажира
        public int PassengerType { get; set; }
    }
}