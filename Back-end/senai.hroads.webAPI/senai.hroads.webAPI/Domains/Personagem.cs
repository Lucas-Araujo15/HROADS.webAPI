using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webAPI.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? IdClasse { get; set; }
        public string Nome { get; set; }
        public byte CapVida { get; set; }
        public byte CapMana { get; set; }
        public DateTime DataAtt { get; set; }
        public DateTime DataCriacao { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual Classe IdClasseNavigation { get; set; }
    }
}
