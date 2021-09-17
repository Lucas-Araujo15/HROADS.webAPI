using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webAPI.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            ClassHabs = new HashSet<ClassHab>();
        }

        public int IdHabilidade { get; set; }
        public int? IdTipoHab { get; set; }
        public string NomeHab { get; set; }

        public virtual TipoHabilidade IdTipoHabNavigation { get; set; }
        public virtual ICollection<ClassHab> ClassHabs { get; set; }
    }
}
