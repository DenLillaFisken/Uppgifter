using System;
using System.Collections.Generic;
using System.Text;

namespace UPG1_VG.Models
{
    class ControlTemperature
    {
        public int Temperature { get; set; }

        public string TempControl(dynamic temp)
        {
            string answer;

            if (temp > 25)
                answer = "The limit has been exceeded!";

            else
                answer = "";

            return answer;
        }
    }
}
