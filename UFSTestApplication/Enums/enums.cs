using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UFSTestApplication.Enums
{
    public static class enums
    {
        public enum PassengerTypes { Infant, Child, Adult};

        public static SelectList PassengerTypeList (int? type)
        {
            IEnumerable<PassengerTypes> values =

                   Enum.GetValues(typeof(PassengerTypes))

                   .Cast<PassengerTypes>();

            IEnumerable<SelectListItem> items =

                from value in values

                select new SelectListItem

                {

                    Text = value.ToString(),

                    Value = value.ToString(),

                    Selected = type.HasValue ? value.ToString() == Enum.GetValues(typeof(PassengerTypes)).GetValue((int)type).ToString() : false
                    // знаю, что дикий костыль, но в Яве есть разница между объектным типом Integer и примитивом int, который позволил бы все решить
                    // простой проверкой на Null аргумента. А тут я еще не успел разобраться, как это делать правильно.

                };
            return new SelectList(items);
        }
    }
}