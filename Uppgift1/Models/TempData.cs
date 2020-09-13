using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1.Models
{
    class TempData
    {
        public int Temperature { get; set; }

        public int GenerateRandomTemp()
        {
            Random rnd = new Random();
            Temperature = rnd.Next(-20, 35);// temperatur mellan -20 till 35 celcius.
            
            return Temperature;
        }

        public string TempControl(int temp)
        {
            string answer;

            if(temp > 25)
            {
                answer = "The limit has been exceeded!";
            }
            else
            {
                answer = "";
            }

            return answer;
        }
    }
}
