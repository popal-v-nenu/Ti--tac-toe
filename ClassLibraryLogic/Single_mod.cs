using System.Runtime.InteropServices;

namespace ClassLibraryLogic
{
    public class Single_mod
    {
        public static int[,] field = new int[3, 3]
        {
            {-1, -1, -1},
            {-1, -1, -1},
            {-1, -1, -1},
        };

        public static void put_x_o(int x, int y, bool is_tic) { field[x, y] = is_tic ? 1 : 0; }
        public static int check_x_o(int x, int y) { return field[x, y]; }
        public static void clear_field() { for (int i = 0; i < 3; i++) for (int j = 0; j < 3; j++) field[i, j] = -1; }
        public static int check_field()
        {
            bool is_draw = true;
            for (int i = 0; i < 3; i++)
            {
                if (field[i, 0] != -1 && field[i, 0] == field[i, 1] && field[i, 1] == field[i, 2]) return field[i, 0];
                if (field[0, i] != -1 && field[0, i] == field[1, i] && field[1, i] == field[2, i]) return field[0, i];
                for (int j = 0; j < 3; j++) if (field[i, j] == -1) is_draw = false;
            }
            if (field[0, 0] != -1 && field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2]) return field[0, 0];
            if (field[0, 2] != -1 && field[0, 2] == field[1, 1] && field[1, 1] == field[2, 0]) return field[0, 2];

            return is_draw ? 2 : -1;
        }
        public static int check_possible_win(bool is_tic)
        {
            int num = is_tic ? 1 : 0;
            //проверка чтобы выйграть
            for (int i = 0; i < 3; i++)
            {
                //горизонтальная проверка
                if (field[i, 0] == -1 && field[i, 1] == num && field[i, 2] == num) return i * 3;
                if (field[i, 0] == num && field[i, 1] == -1 && field[i, 2] == num) return i * 3 + 1;
                if (field[i, 0] == num && field[i, 1] == num && field[i, 2] == -1) return i * 3 + 2;
                //вертикальная проверка
                if (field[0, i] == -1 && field[1, i] == num && field[2, i] == num) return i;
                if (field[0, i] == num && field[1, i] == -1 && field[2, i] == num) return 3 + i;
                if (field[0, i] == num && field[1, i] == num && field[2, i] == -1) return 6 + i;
            }
            //диагональ \
            if (field[0, 0] == -1 && field[1, 1] == num && field[2, 2] == num) return 0;
            if (field[0, 0] == num && field[1, 1] == -1 && field[2, 2] == num) return 4;
            if (field[0, 0] == num && field[1, 1] == num && field[2, 2] == -1) return 8;
            //диагональ /
            if (field[0, 2] == -1 && field[1, 1] == num && field[2, 0] == num) return 2;
            if (field[0, 2] == num && field[1, 1] == -1 && field[2, 0] == num) return 4;
            if (field[0, 2] == num && field[1, 1] == num && field[2, 0] == -1) return 6;

            //return -1;
            //если не один return не сработал то проверка на то чтобы не проиграть
            //меняем значение num на противоположный
            num = is_tic ? 0 : 1;

            for (int i = 0; i < 3; i++)
            {
                //горизонтальная проверка
                if (field[i, 0] == -1 && field[i, 1] == num && field[i, 2] == num) return i * 3;
                if (field[i, 0] == num && field[i, 1] == -1 && field[i, 2] == num) return i * 3 + 1;
                if (field[i, 0] == num && field[i, 1] == num && field[i, 2] == -1) return i * 3 + 2;
                //вертикальная проверка
                if (field[0, i] == -1 && field[1, i] == num && field[2, i] == num) return i;
                if (field[0, i] == num && field[1, i] == -1 && field[2, i] == num) return 3 + i;
                if (field[0, i] == num && field[1, i] == num && field[2, i] == -1) return 6 + i;
            }
            //диагональ \
            if (field[0, 0] == -1 && field[1, 1] == num && field[2, 2] == num) return 0;
            if (field[0, 0] == num && field[1, 1] == -1 && field[2, 2] == num) return 4;
            if (field[0, 0] == num && field[1, 1] == num && field[2, 2] == -1) return 8;
            //диагональ /
            if (field[0, 2] == -1 && field[1, 1] == num && field[2, 0] == num) return 2;
            if (field[0, 2] == num && field[1, 1] == -1 && field[2, 0] == num) return 4;
            if (field[0, 2] == num && field[1, 1] == num && field[2, 0] == -1) return 6;

            return -1;
        }
        public static int check_pattern_diagonal_XOX()
        {
            if (field[1, 1] == 0 && (field[0, 0] == 1 && field[2, 2] == 1 || field[0, 2] == 1 && field[2, 0] == 1))
            {
                Random random = new Random();
                int randomI = random.Next(0, 3);
                int randomJ = random.Next(0, 3);
                while (check_x_o(randomI, randomJ) != -1 || (randomI + randomJ) % 2 == 0)
                {
                    randomI = random.Next(0, 3);
                    randomJ = random.Next(0, 3);
                }
                return randomI * 3 + randomJ;
            }
            return -1;
        }
        public static int check_pattern_diagonal_XXO()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (field[i, j] != -1 && (i + j) % 2 != 0) return -1;
                }
            }
            Random random = new Random();
            int randomI = random.Next(0, 3);
            int randomJ = random.Next(0, 3);
            while (check_x_o(randomI, randomJ) != -1 || (randomI + randomJ) % 2 != 0)
            {
                randomI = random.Next(0, 3);
                randomJ = random.Next(0, 3);
            }
            return randomI * 3 + randomJ;
        }
        public static int check_pattern_minus()
        {
            if (field[1, 0] == 1 && field[1, 1] == 0 && field[1, 2] == 1)
            {
                Random random = new Random();
                int randomI = random.Next(0, 3);
                int randomJ = random.Next(0, 3);
                while (check_x_o(randomI, randomJ) != -1 || (randomI + randomJ) % 2 != 0)
                {
                    randomI = random.Next(0, 3);
                    randomJ = random.Next(0, 3);
                }
                return randomI * 3 + randomJ;
            }
            return -1;
        }
        public static int check_pattern_miniDiagonal()
        {
            if (field[0, 0] == -1 && field[0, 1] == 1 && field[1, 0] == 1) return 0;
            if (field[0, 2] == -1 && field[0, 1] == 1 && field[1, 2] == 1) return 2;
            if (field[2, 0] == -1 && field[2, 1] == 1 && field[1, 0] == 1) return 6;
            if (field[2, 2] == -1 && field[2, 1] == 1 && field[1, 2] == 1) return 8;
            return -1;
        }

        //для крестиков

        public static int check_pick_even()
        {
            Random random = new Random();
            int randomI = random.Next(0, 2);
            int randomJ = random.Next(0, 2);
            if (field[0, 1] == 0)
            {
                //randomJ = random.Next(0, 2);
                if (field[0, randomJ * 2] != -1) if (randomJ == 1) randomJ = 0; else randomJ = 1;
                return randomJ * 2;
            } else if (field[1, 0] == 0)
            {
                if (field[randomI * 2, 0] != -1) if (randomI == 1) randomI = 0; else randomI = 1;
                //randomI = random.Next(0, 2);
                return randomI * 6;
            } else if (field[1, 2] == 0)
            {
                if (field[randomI * 2, 2] != -1) if (randomI == 1) randomI = 0; else randomI = 1;
                //randomI = random.Next(0, 2);
                return randomI * 6 + 2;
            } else if (field[2, 1] == 0)
            {
                if (field[2, randomJ * 2] != -1) if (randomJ == 1) randomJ = 0; else randomJ = 1;
                //randomJ = random.Next(0, 2);
                return randomJ * 2 + 6;
            }
            return -1;
        }
        public static int exists_even(bool is_tic)
        {
            int num = is_tic ? 1 : 0;
            for (int i = 0; i < 3; ++i) for (int j = 0; j < 3; ++j) if (field[i, j] == num && (i + j) % 2 != 0) return i * 3 + j;
            return -1;
        }
        public static int exists_odd(bool is_tic)
        {
            int num = is_tic ? 1 : 0;
            for (int i = 0; i < 3; ++i) for (int j = 0; j < 3; ++j) if (field[i, j] == num && (i + j) % 2 == 0) return i * 3 + j;
            return -1;
        }
        public static int pattern_even_odd(bool is_tic)
        {
            //обработка
            /* 
             _ x _
             _ 0 _
             x _ _ 
            */
            int even = Single_mod.exists_even(!is_tic);
            int odd = Single_mod.exists_odd(!is_tic);
            if (even != -1 && odd != -1)
            {
                int evenRow = even / 3, evenCol = even % 3;
                int oddRow = odd / 3, oddCol = odd % 3;
                //0,1  2,0
                //2,1  2,2
                int exceptionOne = -1, exceptionTwo = -1;
                if (Math.Abs(evenRow - oddRow) == 2)
                {
                    exceptionOne = 3 + (int)((oddRow - evenRow) * 1.5) + 1 + evenCol - oddCol;//угол
                    exceptionTwo = oddRow * 3 + 1;//рядом с углом
                }
                else if (Math.Abs(evenCol - oddCol) == 2)
                {
                    exceptionOne = (1 + (evenRow - oddRow)) * 3 + 1 - (evenCol - oddCol) / 2;//угол
                    exceptionTwo = 4 + (oddCol - evenCol) / 2;//рядом с углом
                }
                //если найдены исключения
                if (exceptionOne != -1)
                {
                    Random random = new Random();
                    int randomI = random.Next(0, 2);
                    int randomJ = random.Next(0, 2);
                    while (Single_mod.check_x_o(randomI, randomJ) != -1 || randomI * 3 + randomJ == exceptionOne || randomI * 3 + randomJ == exceptionTwo)
                    {
                        randomI = random.Next(0, 3);
                        randomJ = random.Next(0, 3);
                    }
                    return randomI * 3 + randomJ;
                }
                
            }
            return -1;

        }
        public static bool exists_odd()
        {
            for (int i = 0; i < 3; i++) for (int j = 0; j < 3; j++) if ((i + j) % 2 == 0 && field[i, j] == -1) return true;
            return false;
        }
    }

}
