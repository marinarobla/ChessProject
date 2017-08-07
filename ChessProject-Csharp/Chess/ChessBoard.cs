using System;

namespace Gfi.Hiring
{
    public class ChessBoard : IChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;

        public static readonly int WhitePawnRow = 1;
        public static readonly int BlackPawnRow = 6;

        private IPiece[,] pieces;

        public ChessBoard()
        {
            pieces = new IPiece[MaxBoardWidth + 1, MaxBoardHeight + 1];
        }

        // Changed Pawn by IPiece so this method can be reused for other pieces
        public void Add(IPiece piece, int xCoordinate, int yCoordinate)
        {
            switch (piece.GetType().Name)
            {
                case nameof(Pawn):
                    AddPawn(piece as Pawn, xCoordinate, yCoordinate);
                    break;
                // Other pieces added here
                // With a private method for each
                default:
                    throw new Exception("Unknown " + piece.GetType().Name + " piece");
            }

        }

        // I don't see necessary passing the PieceColor as a parameter
        // The pawn is built with the color in the constructor so you know beforehand
        // the color of the pawn.
        private void AddPawn(Pawn pawn, int xCoordinate, int yCoordinate)
        {
            int correctRow = (pawn.PieceColor == PieceColor.White) ? WhitePawnRow : BlackPawnRow;
            if (IsLegalBoardPosition(xCoordinate, yCoordinate) && xCoordinate == correctRow && pieces[xCoordinate, yCoordinate] == null)
            {
                pawn.XCoordinate = xCoordinate;
                pawn.YCoordinate = yCoordinate;
            }
            else
            {
                pawn.XCoordinate = -1;
                pawn.YCoordinate = -1;
            }
            pieces[xCoordinate, yCoordinate] = pawn;
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            return (xCoordinate >= 0 && xCoordinate <= MaxBoardWidth && yCoordinate >= 0 && yCoordinate <= MaxBoardHeight);
        }

    }
}
