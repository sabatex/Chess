using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChess.Data
{
    public class ChessParty
    {
        public int Id { get; set; }
        public string WhiteUser { get; set; }
        public string BlackUser { get; set; }
        public DateTime StartTime { get; set; }
        public string Desk { get; set; } // initial

    }
}
