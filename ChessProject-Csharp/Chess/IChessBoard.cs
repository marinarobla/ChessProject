namespace Gfi.Hiring
{
    public interface IChessBoard
    {
        void Add(IPiece piece, int xCoordinate, int yCoordinate);

        bool IsLegalBoardPosition(int xCoordinate, int yCoordinate);
    }
}
