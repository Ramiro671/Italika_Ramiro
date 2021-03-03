using System;
using System.Collections.Generic;

namespace Italika_Ramiro.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            Moto = new HashSet<Moto>();
        }

        public string Tipo1 { get; set; }
        public int IdTipo { get; set; }

        public virtual ICollection<Moto> Moto { get; set; }
    }
}
