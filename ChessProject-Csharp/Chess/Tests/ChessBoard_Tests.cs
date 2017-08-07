using NUnit.Framework;

namespace Gfi.Hiring
{
    [TestFixture]
    public class ChessBoard_Tests
    {
        private ChessBoard _chessBoard;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
        }

        [Test]
        public void Has_MaxBoardWidth_of_7()
        {
            Assert.That(ChessBoard.MaxBoardWidth, Is.EqualTo(7));
        }

        [Test]
        public void Has_MaxBoardHeight_of_7()
        {
            Assert.That(ChessBoard.MaxBoardHeight, Is.EqualTo(7));
        }

        [Test]
        public void IsLegalBoardPosition_True_X_equals_0_Y_equals_0()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(0, 0);
            Assert.That(isValidPosition, Is.True);
        }

        [Test]
        public void IsLegalBoardPosition_True_X_equals_5_Y_equals_5()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(5, 5);
            Assert.That(isValidPosition, Is.True);
        }

        [Test]
        public void IsLegalBoardPosition_False_X_equals_11_Y_equals_5()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(11, 5);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void IsLegalBoardPosition_False_X_equals_0_Y_equals_9()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(0, 9);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void IsLegalBoardPosition_False_X_equals_11_Y_equals_0()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(11, 0);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void IsLegalBoardPosition_False_For_Negative_X_Values()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(-1, 5);
            Assert.That(isValidPosition, Is.False);
        }

        [Test]
        public void IsLegalBoardPosition_False_For_Negative_Y_Values()
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(5, -1);
            Assert.That(isValidPosition, Is.False);
        }
        [Test]
        public void Avoids_Duplicate_Positioning()
        {
            Pawn firstPawn = new Pawn(PieceColor.Black, this._chessBoard);
            Pawn secondPawn = new Pawn(PieceColor.Black, this._chessBoard);
            _chessBoard.Add(firstPawn, 6, 3);
            _chessBoard.Add(secondPawn, 6, 3);
            Assert.That(firstPawn.XCoordinate, Is.EqualTo(6));
            Assert.That(firstPawn.YCoordinate, Is.EqualTo(3));
            Assert.That(secondPawn.XCoordinate, Is.EqualTo(-1));
            Assert.That(secondPawn.YCoordinate, Is.EqualTo(-1));
        }

        [Test]
        public void Limits_The_Number_Of_Pawns()
        {
            for (int i = 0; i < 10; i++)
            {
                Pawn pawn = new Pawn(PieceColor.Black, this._chessBoard);
                int row = i / ChessBoard.MaxBoardWidth;
                _chessBoard.Add(pawn, 6 + row, i % ChessBoard.MaxBoardWidth);
                if (row < 1)
                {
                    Assert.That(pawn.XCoordinate, Is.EqualTo(6 + row));
                    Assert.That(pawn.YCoordinate, Is.EqualTo(i % ChessBoard.MaxBoardWidth));
                }
                else
                {
                    Assert.That(pawn.XCoordinate, Is.EqualTo(-1));
                    Assert.That(pawn.YCoordinate, Is.EqualTo(-1));
                }
            }
        }

        // Some people prefer parametrized tests. Others more descriptive ones (using the name of the function)
        // As an example I have compiled a group of the given ones into a parametrized version so only one method is called multiple times
        [TestCase(0, 0, true)]
        [TestCase(5, 5, true)]
        [TestCase(11, 5, false)]
        [TestCase(0, 9, false)]
        [TestCase(11, 0, false)]
        [TestCase(-1, 5, false)]
        [TestCase(5, -1, false)]
        public void IsLegalBoardPosition(int xCoordinate, int yCoordinate, bool expected)
        {
            var isValidPosition = _chessBoard.IsLegalBoardPosition(xCoordinate, yCoordinate);
            Assert.That(isValidPosition, Is.EqualTo(expected));
        }
    }
}
