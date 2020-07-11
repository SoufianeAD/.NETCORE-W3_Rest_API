using System;
using System.Collections.Generic;

namespace HasniAPI.Model
{
    public partial class Depot
    {
        public Depot()
        {
            Magasin = new HashSet<Magasin>();
        }

        public int IdDepot { get; set; }
        public int? IdVille { get; set; }
        public bool? IsMagasin { get; set; }
        public string Reference { get; set; }
        public string NomDepot { get; set; }
        public string Adresse { get; set; }
        public string Tele { get; set; }
        public string Fax { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? Supprime { get; set; }

        public virtual ICollection<Magasin> Magasin { get; set; }
    }
}
