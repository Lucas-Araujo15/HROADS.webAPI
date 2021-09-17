using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webAPI.Domains
{
    public partial class ClassHab
    {
        public int IdClassHab { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? IdClasse { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? IdHabilidade { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}
