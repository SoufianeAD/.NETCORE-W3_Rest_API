using System;
using System.Collections.Generic;

namespace HasniAPI.Model
{
    public partial class ArticleXCommande
    {
        public int Id { get; set; }
        public int IdArticle { get; set; }
        public int IdCommande { get; set; }
        public decimal? QuantiteCommandee { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? Supprime { get; set; }
        public decimal? TauxTva { get; set; }
        public decimal? Prix { get; set; }
        public string Designation { get; set; }
        public decimal? QuantiteLivree { get; set; }
        public decimal? PrixTtc { get; set; }

        public virtual Article IdArticleNavigation { get; set; }
        public virtual Commande IdCommandeNavigation { get; set; }
    }
}
