using System;
using System.Collections.Generic;

namespace HasniAPI.Model
{
    public partial class Sousfamillearticle
    {
        public Sousfamillearticle()
        {
            Article = new HashSet<Article>();
        }

        public int IdSousFamille { get; set; }
        public string LibelleSousFamille { get; set; }
        public string Description { get; set; }
        public int? IdFamilleArticle { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? Supprimer { get; set; }
        public string CodeSf { get; set; }

        public virtual Famillearticle IdFamilleArticleNavigation { get; set; }
        public virtual ICollection<Article> Article { get; set; }
    }
}
