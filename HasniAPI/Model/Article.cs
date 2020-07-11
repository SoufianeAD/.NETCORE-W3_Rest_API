using System;
using System.Collections.Generic;

namespace HasniAPI.Model
{
    public partial class Article
    {
        public Article()
        {
            ArticleXCommande = new HashSet<ArticleXCommande>();
        }

        public int IdArticle { get; set; }
        public int? IdTva { get; set; }
        public int? IdFamilleArticle { get; set; }
        public string RefArticle { get; set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public decimal? PrixVenteArticleHt { get; set; }
        public bool? Supprime { get; set; }
        public string Unite { get; set; }
        public int? IdFournisseur { get; set; }
        public decimal? PrixAchat { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public decimal? StockMin { get; set; }
        public decimal? StockMax { get; set; }
        public decimal? Pmp { get; set; }
        public decimal? PrixMin { get; set; }
        public byte[] Image { get; set; }
        public string NomImage { get; set; }
        public string TypeImage { get; set; }
        public decimal? PrixVenteArticleTtc { get; set; }
        public decimal? PrixMinTtc { get; set; }
        public decimal? PrixAchatTtc { get; set; }
        public string CodeAbarre { get; set; }
        public string EncodageType { get; set; }
        public string CodeFrs { get; set; }
        public decimal? NbreParColis { get; set; }
        public decimal? QteParColis { get; set; }
        public string CodeF { get; set; }
        public string CodeSf { get; set; }
        public decimal? Colis { get; set; }
        public decimal? QteParClois { get; set; }
        public int? IsPlinthe { get; set; }
        public decimal? Stock { get; set; }
        public decimal? PrixHamria { get; set; }
        public decimal? PrixZitoune { get; set; }
        public decimal? DernierPrixAchat { get; set; }
        public decimal? DernierPrixVente { get; set; }
        public decimal? Pmpachat { get; set; }
        public decimal? Pmpvente { get; set; }
        public bool? IsMouvemente { get; set; }
        public decimal? PrixAchatHamria { get; set; }
        public decimal? PrixAchatZitoune { get; set; }

        public virtual Sousfamillearticle IdFamilleArticleNavigation { get; set; }
        public virtual Tva IdTvaNavigation { get; set; }
        public virtual ICollection<ArticleXCommande> ArticleXCommande { get; set; }
    }
}
