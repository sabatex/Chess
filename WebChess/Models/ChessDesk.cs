using Chess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebChess.Models
{
    public class ChessDesk
    {
        public FigureColor currentPlayer { get; set; }
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
            for (int i = 0; i < 8; i++) result.Add(new Figure() { Color = FigureColor.Black, CanMoves = new DestinationCell[] { }, FigureType = FigureType.Pawn });
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
            updateMoves();
        }

        Figure GetFigureById(int row, int column)
        {
            return Desk[row * 8 + column];
        }

        MoveState CheckMove(Figure figure, int row, int column, int destinationRow, int destinationColumn)
        {
            if (currentPlayer != figure.Color) return MoveState.Cannot;
            
            return MoveState.Can;
        }


        DestinationCell[] getMovePositions(int row, int column)
        {
            var result = new List<DestinationCell>();
            var figure = GetFigureById(row, column);
            if (figure == null) return result.ToArray();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var r = CheckMove(figure, row, column, i, j);
                    if (r == MoveState.Can || r == MoveState.Fight)
                    {
                        result.Add(new DestinationCell() { Column = i, Row = j, State = r });
                    }
                }
            }
            return result.ToArray();
        }

        void updateMoves()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var figure = GetFigureById(i, j);
                    if (figure != null)
                    {
                        figure.CanMoves = getMovePositions(i, j);
                    }
                }

            }
        }
    }

}
