using NUnit.Framework;

namespace Gfi.Hiring
{
    [TestFixture]
    public class Pawn_Tests
    {
        private ChessBoard _chessBoard;
        // Missing all white's tests as they are positioned in a different place and move in a different direction.
        // I think that they need their own tests
        private Pawn _blackPawn;
        private Pawn _whitePawn;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
            _blackPawn = new Pawn(PieceColor.Black, this._chessBoard);
            _whitePawn = new Pawn(PieceColor.White, this._chessBoard);
        }

        [Test]
        public void ChessBoard_Add_Sets_XCoordinate_Black()
        {
            _chessBoard.Add(_blackPawn, 6, 3);
            Assert.That(_blackPawn.XCoordinate, Is.EqualTo(6));
        }

        [Test]
        public void ChessBoard_Add_Sets_YCoordinate_Black()
        {
            _chessBoard.Add(_blackPawn, 6, 3);
            Assert.That(_blackPawn.YCoordinate, Is.EqualTo(3));
        }

        // According to the README file:
        // Black pieces typically start at row x=7 and x=6, whereas white pieces typically start at rows x=0 and x=1.
        // Using this coordinates system, right-left moves will be done by the Y coordinate
        // This applies to all left-right and forwards tests
        [Test]
        public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove_Black()
        {
            _chessBoard.Add(_blackPawn, 6, 3);
            _blackPawn.Move(MovementType.Move, 6, 4);
            Assert.That(_blackPawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_blackPawn.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove_Black()
        {
            _chessBoard.Add(_blackPawn, 6, 3);
            _blackPawn.Move(MovementType.Move, 6, 2);
            Assert.That(_blackPawn.XCoordinate, Is.EqualTo(6));
            Assert.That(_blackPawn.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates_Black()
        {
            _chessBoard.Add(_blackPawn, 6, 3);
            _blackPawn.Move(MovementType.Move, 5, 3);
            Assert.That(_blackPawn.XCoordinate, Is.EqualTo(5));
            Assert.That(_blackPawn.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void ChessBoard_Add_Sets_XCoordinate_White()
        {
            _chessBoard.Add(_whitePawn, 1, 3);
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(1));
        }

        [Test]
        public void ChessBoard_Add_Sets_YCoordinate_White()
        {
            _chessBoard.Add(_whitePawn, 1, 3);
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove_White()
        {
            _chessBoard.Add(_whitePawn, 1, 3);
            _whitePawn.Move(MovementType.Move, 1, 4);
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(1));
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove_White()
        {
            _chessBoard.Add(_whitePawn, 1, 3);
            _whitePawn.Move(MovementType.Move, 1, 2);
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(1));
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(3));
        }

        [Test]
        public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates_White()
        {
            _chessBoard.Add(_whitePawn, 1, 3);
            _whitePawn.Move(MovementType.Move, 2, 3);
            Assert.That(_whitePawn.XCoordinate, Is.EqualTo(2));
            Assert.That(_whitePawn.YCoordinate, Is.EqualTo(3));
        }

    }
}
