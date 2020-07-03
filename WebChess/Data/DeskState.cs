using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChess.Data
{
    public class DeskState
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string UserMove { get; set; }
        public string Step { get; set; }
        public string Desk { get; set; }
        public ChessParty ChessParty { get; set; }
    }
}
