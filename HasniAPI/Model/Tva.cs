using System;
using System.Collections.Generic;

namespace HasniAPI.Model
{
    public partial class Tva
    {
        public Tva()
        {
            Article = new HashSet<Article>();
        }

        public int IdTva { get; set; }
        public decimal? TauxTva { get; set; }
        public string CodeTva { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? Supprime { get; set; }

        public virtual ICollection<Article> Article { get; set; }
    }
}
