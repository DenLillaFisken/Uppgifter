using System;
using System.Collections.Generic;
using System.Text;

namespace UPG2.Models
{
    class Message
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //OBS! Bra att kunna!
        public string FullName => $"{FirstName} {LastName}";

        public string EmailMessage { get; set; }
        public string EmailDate { get; set; }
        public string EmailTime { get; set; }


    }
}
