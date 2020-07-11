using System;
using System.Collections.Generic;

namespace HasniAPI.Model
{
    public partial class Familleclient
    {
        public Familleclient()
        {
            Client = new HashSet<Client>();
        }

        public int IdFamilleClient { get; set; }
        public string LibelleFamilleClt { get; set; }
        public DateTime? DateCreation { get; set; }
        public DateTime? DateModification { get; set; }
        public bool? Supprime { get; set; }

        public virtual ICollection<Client> Client { get; set; }
    }
}
