using System;

namespace Gfi.Hiring
{
    public class Pawn : Piece
    {
        public Pawn(PieceColor pieceColor, IChessBoard chessBoard) : base(pieceColor, chessBoard)
        {
        }

        public override void Move(MovementType movementType, int newX, int newY)
        {
            int expectedXCoordinate = this.PieceColor == PieceColor.White ? this.XCoordinate + 1 : this.XCoordinate - 1;

            if (movementType == MovementType.Move)
            {
                if (this.ChessBoard.IsLegalBoardPosition(newX, newY) && expectedXCoordinate == newX && this.YCoordinate == newY)
                {
                    this.XCoordinate = newX;
                    this.YCoordinate = newY;
                }
            }
            else if (movementType == MovementType.Capture)
            {
                if (this.ChessBoard.IsLegalBoardPosition(newX, newY) && expectedXCoordinate == newX &&
                    (this.YCoordinate - 1 == newY || this.YCoordinate + 1 == newY))
                {
                    this.XCoordinate = newX;
                    this.YCoordinate = newY;
                }
            }
        }

    }
}
