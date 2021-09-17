using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webAPI.Domains
{
    public partial class TipoHabilidade
    {
        public TipoHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTipoHab { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string NomeTipoHab { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
