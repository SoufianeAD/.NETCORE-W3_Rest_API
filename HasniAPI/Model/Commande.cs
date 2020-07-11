using System;
using System.Collections.Generic;

namespace HasniAPI.Model
{
    public partial class Commande
    {
        public Commande()
        {
            ArticleXCommande = new HashSet<ArticleXCommande>();
        }

        public int IdCommande { get; set; }
        public int? IdDevis { get; set; }
        public int? IdClient { get; set; }
        public string RefCommande { get; set; }
        public int? NumCommande { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public DateTime? DateCommande { get; set; }
        public string Remarque { get; set; }
        public bool? Supprime { get; set; }
        public int? IdMagasin { get; set; }
        public int? IdUser { get; set; }
        public int? IdExercice { get; set; }
        public DateTime? IsReported { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual Magasin IdMagasinNavigation { get; set; }
        public virtual ICollection<ArticleXCommande> ArticleXCommande { get; set; }
    }
}
