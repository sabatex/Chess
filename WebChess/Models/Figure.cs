using Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChess.Models
{
    public class Figure
    {
        public FigureColor  Color { get; set; }
        public bool FistMove { get; set; }
        public FigureType FigureType { get; set; }
        public DestinationCell[] CanMoves { get; set; }

    }
}
