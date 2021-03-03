using System;
using System.Collections.Generic;

namespace Italika_Ramiro.Models
{
    public partial class Moto
    {
        public string Sku { get; set; }
        public string Fert { get; set; }
        public string Modelo { get; set; }
        public int IdTipo { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdMoto { get; set; }

        public virtual Tipo IdTipoNavigation { get; set; }
    }
}
