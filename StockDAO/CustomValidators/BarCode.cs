using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace StockDAO.CustomValidators
{
    public class BarCode : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public static int NumberOfDigits = 13;
        public string InputValue { get; set; }

        public override bool IsValid(object value)
        {
            InputValue = value as string;
            if (InputValue.Length != 13)
            {
                return false;
            }
            return true;
        }

    }
}
