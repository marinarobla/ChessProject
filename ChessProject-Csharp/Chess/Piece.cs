using System;

namespace Gfi.Hiring
{
    public abstract class Piece : IPiece
    {
        public IChessBoard ChessBoard { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public PieceColor PieceColor { get; set; }

        public abstract void Move(MovementType movementType, int newX, int newY);

        protected Piece(PieceColor pieceColor, IChessBoard chessBoard)
        {
            PieceColor = pieceColor;
            ChessBoard = chessBoard;
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }
    }
}
