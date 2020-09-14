using System;
using System.Collections.Generic;
using System.Text;

namespace UPG1_VG.Models
{
    class ConvertToCelsius
    {
        public int Temperature { get; set; }

        public double TempConverter(dynamic temp)
        {
            double kelvin = Convert.ToDouble(temp);
            double celsius = Math.Round(kelvin - 273.15, 1);

            return celsius;
        }
    }
}
