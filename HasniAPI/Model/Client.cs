using System;
using System.Collections.Generic;

namespace HasniAPI.Model
{
    public partial class Client
    {
        public Client()
        {
            Commande = new HashSet<Commande>();
        }

        public int IdClient { get; set; }
        public int? IdFamilleClient { get; set; }
        public string RefClt { get; set; }
        public string NomClient { get; set; }
        public string Description { get; set; }
        public string NumTele { get; set; }
        public string NumFax { get; set; }
        public string EmailClient { get; set; }
        public string SiteWebClient { get; set; }
        public string ContactClient { get; set; }
        public string Adresse { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? Supprime { get; set; }
        public bool? IsBloque { get; set; }
        public string AddresseFacturation { get; set; }
        public string Banque { get; set; }
        public string Agence { get; set; }
        public string Compte { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public decimal? SoldeMaximum { get; set; }
        public string Ville { get; set; }
        public int? NumClient { get; set; }

        public virtual Familleclient IdFamilleClientNavigation { get; set; }
        public virtual ICollection<Commande> Commande { get; set; }
    }
}
