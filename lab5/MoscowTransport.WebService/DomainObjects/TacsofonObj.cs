using System;
using System.Collections.Generic;
using System.Text;

namespace TacsofonObj.DomainObjects
{
    public class TacsofonObj : DomainObject
    {
        public string Name { get; set; }
        public string Adres { get; set; }
        public string Oplata { get; set; }

        public string Platnost { get; set; }

        public string Card { get; set; }



    }
}
