﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO {
    public class Arme {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Degats { get; set; }

        override public string ToString() {
            return Nom;
        }
    }
}
