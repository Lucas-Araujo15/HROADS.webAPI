using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webAPI.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            ClassHabs = new HashSet<ClassHab>();
            Personagems = new HashSet<Personagem>();
        }

        public int IdClasse { get; set; }
        public string NomeClasse { get; set; }
        public virtual ICollection<ClassHab> ClassHabs { get; set; }
        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
