﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Dependente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public virtual Cliente cliente { get; set; } // virtual = LasyLoad
        public string Info { get; set; }

    }
}
