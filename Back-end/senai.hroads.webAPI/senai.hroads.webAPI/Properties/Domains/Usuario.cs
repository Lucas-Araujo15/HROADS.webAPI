using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webAPI.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
