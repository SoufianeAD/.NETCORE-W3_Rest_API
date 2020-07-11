using System;
using System.Collections.Generic;

namespace HasniAPI.Model
{
    public partial class Magasin
    {
        public Magasin()
        {
            Commande = new HashSet<Commande>();
        }

        public int IdMagasin { get; set; }
        public int? IdDepot { get; set; }
        public int? IdVille { get; set; }
        public string Reference { get; set; }
        public string NomMagasin { get; set; }
        public string Adresse { get; set; }
        public string Tele { get; set; }
        public string Fax { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? Supprime { get; set; }

        public virtual Depot IdDepotNavigation { get; set; }
        public virtual ICollection<Commande> Commande { get; set; }
    }
}
