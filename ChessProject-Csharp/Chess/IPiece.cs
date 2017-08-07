namespace Gfi.Hiring
{
    public interface IPiece
    {
        IChessBoard ChessBoard { get; set; }

        int XCoordinate { get; set; }

        int YCoordinate { get; set; }

        PieceColor PieceColor { get; set; }

        void Move(MovementType movementType, int newX, int newY);
    }
}
