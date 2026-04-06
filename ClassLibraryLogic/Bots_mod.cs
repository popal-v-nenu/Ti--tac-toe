using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogic
{
    public class Bots_mod
    {

        public static int count_move = 0;
        public static void reset_count_move() { count_move = 0; }
        public static int easy_bot(bool is_tic)
        {
            Random random = new Random();
            int randomI = random.Next(0, 3);
            int randomJ = random.Next(0, 3);



            while (Single_mod.check_x_o(randomI, randomJ) != -1)
            {
                randomI = random.Next(0, 3);
                randomJ = random.Next(0, 3);
            }
            Single_mod.put_x_o(randomI, randomJ, is_tic);
            count_move++;
            return randomI * 3 + randomJ;
        }
        public static int medium_bot(bool is_tic)
        {
            Random random = new Random();
            int randomI = random.Next(0, 3);
            int randomJ = random.Next(0, 3);
            
            int choice = Single_mod.check_possible_win(is_tic);
            if (choice != -1) return choice;
            while (Single_mod.check_x_o(randomI, randomJ) != -1)
            {
                randomI = random.Next(0, 3);
                randomJ = random.Next(0, 3);
            }   
            
            Single_mod.put_x_o(randomI, randomJ, is_tic);
            count_move++;
            return randomI * 3 + randomJ;
        }
        public static int impossible_bot(bool is_tic)
        {
            Random random = new Random();
            int randomI = random.Next(0, 3);
            int randomJ = random.Next(0, 3);
            count_move++;
            if (count_move == 1)
            {
                //return 4;

                //проверка для ноликов
                if (Single_mod.check_x_o(1, 1) == -1 && !is_tic) return 4;
                //проверка на четную клектку для крестиков
                
                while (Single_mod.check_x_o(randomI, randomJ) != -1 || (randomI + randomJ) % 2 != 0)
                {
                    randomI = random.Next(0, 3);
                    randomJ = random.Next(0, 3);
                }
            }
            else
            {

                int choice = Single_mod.check_possible_win(is_tic);
                if (choice != -1) return choice;
                //проверка паттерна с диагональю только за ноликов
                if (!is_tic)
                {
                    //проверка на выйгрышь
                    choice = Single_mod.check_pattern_minus();
                    //проверка на проигрышь
                    if (choice != -1) return choice;
                    choice = Single_mod.check_pattern_miniDiagonal();
                    if (choice != -1) return choice;
                    choice = Single_mod.check_pattern_diagonal_XOX();
                    if (choice != -1) return choice;
                    choice = Single_mod.check_pattern_diagonal_XXO();
                    if (choice != -1) return choice;
                }
                else
                {
                    //проверка для крестиков
                    //проверка на свободный центр
                    if (Single_mod.check_x_o(1, 1) == -1) return 4;
                    if (count_move == 2)
                    {
                        choice = Single_mod.check_pick_even();
                        if (choice != -1) return choice;
                    }
                    else if (count_move == 3)
                    {
                        choice = Single_mod.check_pick_even();
                        switch (choice)
                        {
                            case 0:
                                while (Single_mod.check_x_o(randomI, randomJ) != -1 || randomI == 0 && randomJ == 0 || (randomI + randomJ) % 2 != 0)
                                {
                                    randomI = random.Next(0, 3);
                                    randomJ = random.Next(0, 3);
                                }
                                return randomI * 3 + randomJ;
                            case 2:
                                while (Single_mod.check_x_o(randomI, randomJ) != -1 || randomI == 0 && randomJ == 2 || (randomI + randomJ) % 2 != 0)
                                {
                                    randomI = random.Next(0, 3);
                                    randomJ = random.Next(0, 3);
                                }
                                return randomI * 3 + randomJ;
                            case 6:
                                while (Single_mod.check_x_o(randomI, randomJ) != -1 || randomI == 2 && randomJ == 0 || (randomI + randomJ) % 2 != 0)
                                {
                                    randomI = random.Next(0, 3);
                                    randomJ = random.Next(0, 3);
                                }
                                return randomI * 3 + randomJ;
                            case 8:
                                while (Single_mod.check_x_o(randomI, randomJ) != -1 || randomI == 2 && randomJ == 2 || (randomI + randomJ) % 2 != 0)
                                {
                                    randomI = random.Next(0, 3);
                                    randomJ = random.Next(0, 3);
                                }
                                return randomI * 3 + randomJ;

                        }
                    }

                }
                
                if (count_move >= 4)
                {
                    while (Single_mod.check_x_o(randomI, randomJ) != -1)
                    {
                        randomI = random.Next(0, 3);
                        randomJ = random.Next(0, 3);
                    }
                }
                else
                {
                    while (Single_mod.check_x_o(randomI, randomJ) != -1 || (randomI + randomJ) % 2 != 0)
                    {
                        randomI = random.Next(0, 3);
                        randomJ = random.Next(0, 3);
                    }
                }

            }
            

            Single_mod.put_x_o(randomI, randomJ, is_tic);
            
            return randomI * 3 + randomJ;
        }
    }
}
