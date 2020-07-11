using System;
using System.Collections.Generic;

namespace HasniAPI.Model
{
    public partial class Famillearticle
    {
        public Famillearticle()
        {
            Sousfamillearticle = new HashSet<Sousfamillearticle>();
        }

        public int IdFamilleArticle { get; set; }
        public string LibelleFamArticle { get; set; }
        public string Description { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? Supprime { get; set; }
        public string CodeFamille { get; set; }
        public int? IsCarreaux { get; set; }

        public virtual ICollection<Sousfamillearticle> Sousfamillearticle { get; set; }
    }
}
