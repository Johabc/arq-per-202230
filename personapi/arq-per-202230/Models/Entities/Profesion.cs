using System;
using System.Collections.Generic;

namespace arq_per_202230.Models.Entities
{
    public partial class Profesion
    {
        public Profesion()
        {
            Estudios = new HashSet<Estudio>();
        }

        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Dest { get; set; }

        public virtual ICollection<Estudio> Estudios { get; set; }
    }
}
