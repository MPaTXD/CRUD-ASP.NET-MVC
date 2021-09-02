using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD.Models
{
    public class MusicoBanda
    {
        public int MusicoBandaId { get; set; }

        [ForeignKey("Musico")]
        public int MusicoId { get; set; }
        public Musico Musico { get; set; }

        [ForeignKey("Banda")]

        public int BandaId { get; set; }

        public Banda Banda { get; set; }
    }
}