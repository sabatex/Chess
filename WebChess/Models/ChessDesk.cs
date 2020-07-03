using Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebChess.Models
{
    public class ChessDesk
    {
        public FigureColor  currentPlayer { get; set; }
        public Figure[] Desk { get; set; }

        Figure[] Initial()
        {
            var result = new List<Figure>();
            result.Add(new Figure() { Color = FigureColor.Black, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Rook });
            result.Add(new Figure() { Color = FigureColor.Black, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Horse });
            result.Add(new Figure() { Color = FigureColor.Black, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Bishop });
            result.Add(new Figure() { Color = FigureColor.Black, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Queen });
            result.Add(new Figure() { Color = FigureColor.Black, CanMoves = new DestinationCell[] { }, FigureType = FigureType.King });
            result.Add(new Figure() { Color = FigureColor.Black, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Bishop });
            result.Add(new Figure() { Color = FigureColor.Black, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Horse });
            result.Add(new Figure() { Color = FigureColor.Black, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Rook });
            for (int i=0;i<8;i++) result.Add(new Figure() { Color = FigureColor.Black, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Pawn });
            for (int i = 0; i < 32; i++) result.Add(null);
            for (int i = 0; i < 8; i++) result.Add(new Figure() { Color = FigureColor.White, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Pawn });
            result.Add(new Figure() { Color = FigureColor.White, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Rook });
            result.Add(new Figure() { Color = FigureColor.White, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Horse });
            result.Add(new Figure() { Color = FigureColor.White, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Bishop });
            result.Add(new Figure() { Color = FigureColor.White, CanMoves = new DestinationCell[] { }, FigureType = FigureType.King });
            result.Add(new Figure() { Color = FigureColor.White, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Queen });
            result.Add(new Figure() { Color = FigureColor.White, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Bishop });
            result.Add(new Figure() { Color = FigureColor.White, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Horse });
            result.Add(new Figure() { Color = FigureColor.White, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Rook });
            return result.ToArray();
        }

        public ChessDesk()
        {
            currentPlayer = FigureColor.White;
            Desk = Initial();
        }
    }
}
