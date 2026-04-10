using ClassLibraryLogic;
using NUnit.Framework;
using NUnit.Framework.Legacy;


namespace TestProjectTic_tac_toe
{
    public class Tests
    {
        private Field _field;

        [SetUp]
        public void Setup()
        {
            _field = new Field();
        }

        [Test]
        public void Unfinished_game()
        {
            // Arrange
            int[,] array = new int[3, 3]
            {
                {-1, -1, -1},
                {-1, -1, -1},
                {-1, -1, -1},
            };
            int expected = -1;

            // Act
            int result = _field.check_field(array);

            // Assert
            ClassicAssert.AreEqual(expected, result, "незаконченная игра должна возвращать -1");
        }



        [Test]
        public void Win_O()
        {
            // Arrange - поле с победой X (1)
            int[,] array = new int[3, 3]
            {
                {0, 0, 0},
                {-1, -1, -1},
                {-1, -1, -1},
            };
            int expected = 0;

            // Act
            int result = _field.check_field(array);

            // Assert
            ClassicAssert.AreEqual(expected, result, "победа ноликов должна возвращать 0");
        }

        [Test]
        public void Win_X()
        {
            // Arrange - поле с победой X (1)
            int[,] array = new int[3, 3]
            {
                {1, 1, 1},
                {-1, -1, -1},
                {-1, -1, -1},
            };
            int expected = 1;

            // Act
            int result = _field.check_field(array);

            // Assert
            ClassicAssert.AreEqual(expected, result, "победа крестиков должна возвращать 1");
        }

        [Test]
        public void Draw()
        {
            // Arrange - поле с победой X (1)
            int[,] array = new int[3, 3]
            {
                {1, 0, 1},
                {1, 1, 0},
                {0, 1, 0},
            };
            int expected = 2;

            // Act
            int result = _field.check_field(array);

            // Assert
            ClassicAssert.AreEqual(expected, result, "ничья должна возвращать 2");
        }

        [Test]
        public void PossibleWin_For_O()
        {
            int[,] array = new int[3, 3]
            {
                {-1, -1, -1},
                {-1, 0, 1},
                {1, 0, 1},
            };
            int expected = 1;

            // Act
            int result = _field.check_possible_win(false, array);

            // Assert
            ClassicAssert.AreEqual(expected, result, "приоритет выйграть а не защититься за ноликов");
        }

        [Test]
        public void Defence_For_O()
        {
            int[,] array = new int[3, 3]
            {
                {-1, -1, -1},
                {-1, -1, 1},
                {-1, 0, 1},
            };
            int expected = 2;

            // Act
            int result = _field.check_possible_win(false, array);

            // Assert
            ClassicAssert.AreEqual(expected, result, "нолик должен защищаться");
        }

        [Test]
        public void PossibleWin_For_X()
        {
            int[,] array = new int[3, 3]
            {
                {-1, -1, -1},
                {-1, 0, 1},
                {1, 0, 1},
            };
            int expected = 2;

            // Act
            int result = _field.check_possible_win(true, array);

            // Assert
            ClassicAssert.AreEqual(expected, result, "приоритет выйграть а не защититься за крестиков");
        }

        [Test]
        public void Defence_For_X()
        {
            int[,] array = new int[3, 3]
            {
                {-1, -1, -1},
                {-1, 0, -1},
                {1, 0, 1},
            };
            int expected = 1;

            // Act
            int result = _field.check_possible_win(true, array);

            // Assert
            ClassicAssert.AreEqual(expected, result, "крестик должен защищаться");
        }

        [Test]
        public void Pattern_XOX()
        {
            int[,] array = new int[3, 3]
            {
                {1, -1, -1}, 
                {-1, 0, -1},
                {-1, -1, 1},
            };
            int expected = 1;

            // Act
            int result = _field.check_pattern_diagonal_XOX(array) % 2;

            // Assert
            ClassicAssert.AreEqual(expected, result, "нолик должен ставиться на четную клетку");
        }

        [Test]
        public void Pattern_XXO()
        {
            int[,] array = new int[3, 3]
            {
                {-1, -1, 0},
                {-1, 1, -1},
                {1, -1, -1},
            };
            int expected = 0;

            // Act
            int result = _field.check_pattern_diagonal_XXO(array) % 2;

            // Assert
            ClassicAssert.AreEqual(expected, result, "нолик должен ставиться на нечетную клетку");
        }
    }

        
}