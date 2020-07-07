using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebChess.Data
{
    public class ChessParty
    {
        public int Id { get; set; }
        public string UserWhite { get; set; }
        public string UserBlack { get; set; }
        public DateTime StartDate { get; set; }
        public int? LastParty { get; set; }

    }
}
