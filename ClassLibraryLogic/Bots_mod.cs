using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLogic
{
    public class Bots_mod
    {

        public static int countMove = 0;
        public static void reset_count_move() { countMove = 0; }
        public static int easy_bot(bool is_tic)
        {
            Random random = new Random();
            int randomI = random.Next(0, 3);
            int randomJ = random.Next(0, 3);



            while (Field.check_x_o(randomI, randomJ) != -1)
            {
                randomI = random.Next(0, 3);
                randomJ = random.Next(0, 3);
            }
            Field.put_x_o(randomI, randomJ, is_tic);
            countMove++;
            return randomI * 3 + randomJ;
        }
        public static int medium_bot(bool is_tic)
        {
            Random random = new Random();
            int randomI = random.Next(0, 3);
            int randomJ = random.Next(0, 3);

            Field field = new Field();
            
            int choice = field.check_possible_win(is_tic, Field.field);
            if (choice != -1) return choice;
            while (Field.check_x_o(randomI, randomJ) != -1)
            {
                randomI = random.Next(0, 3);
                randomJ = random.Next(0, 3);
            }   
            
            Field.put_x_o(randomI, randomJ, is_tic);
            countMove++;
            return randomI * 3 + randomJ;
        }
        public static int impossible_bot(bool is_tic)
        {
            Random random = new Random();
            int randomI = random.Next(0, 3);
            int randomJ = random.Next(0, 3);

            Field field = new Field();

            countMove++;
            if (countMove == 1)
            {
                //return 4;

                //проверка для ноликов
                if (Field.check_x_o(1, 1) == -1 && !is_tic)  return 4;
                //проверка на четную клектку                
                while (Field.check_x_o(randomI, randomJ) != -1 || (randomI + randomJ) % 2 != 0)
                {
                    randomI = random.Next(0, 3);
                    randomJ = random.Next(0, 3);
                }
            }
            else
            {
                int choice;
                //проверка за ноликов
                if (!is_tic)
                {
                    //возможный выйгрышь или защита за ноликов
                    choice = field.check_possible_win(!is_tic, Field.field);
                    if (choice != -1) return choice;

                    //проверка на выйгрышь
                    choice = Field.check_pattern_minus();
                    if (choice != -1) return choice;

                    if (countMove == 2)
                    {
                        choice = Field.check_pattern_miniDiagonal();
                        if (choice != -1) return choice;

                        choice = Field.pattern_even_odd(is_tic);
                        if (choice != -1) return choice;

                        choice = field.check_pattern_diagonal_XOX(Field.field);
                        if (choice != -1) return choice;

                        choice = field.check_pattern_diagonal_XXO(Field.field);
                        if (choice != -1) return choice;
                    }
                    if (Field.exists_odd())
                    {
                        while (Field.check_x_o(randomI, randomJ) != -1 || (randomI + randomJ) % 2 != 0)
                        {
                            randomI = random.Next(0, 3);
                            randomJ = random.Next(0, 3);
                        }
                    }
                    while (Field.check_x_o(randomI, randomJ) != -1)
                    {
                        randomI = random.Next(0, 3);
                        randomJ = random.Next(0, 3);
                    }


                }
                else
                {
                    //проверка для крестиков
                    //возможный выйгрышь за крестиков
                    choice = field.check_possible_win(is_tic, Field.field);
                    if (choice != -1) return choice;

                    
                    if (countMove == 2)
                    {
                        //проверка x_o
                        choice = Field.check_line();
                        if (choice != -1) return choice;

                        //проверка противоположных углов
                        choice = Field.opposites();
                        if (choice != -1) return choice;

                        //проверка на свободный центр
                        if (Field.check_x_o(1, 1) == -1) return 4;

                        choice = Field.check_pick_even();
                        if (choice != -1) return choice;
                    }
                    else if (countMove == 3)
                    {
                        //проверка opposites
                        int opposites = Field.opposites();
                        if (opposites != -1 && Field.check_x_o(1, 1) == -1)
                        {
                            
                            int rnd = random.Next(0, 2);
                            int num = opposites / 3 == opposites % 3 ? 0 : 1;
                            int ret = (rnd * 6 + (rnd - num) * 2);
                            if (Field.check_x_o(ret / 3, ret % 3) == -1) return ret;
                            else return ((1 - rnd) * 6) + (1 - rnd - num) * 2;
                        }
                        

                        choice = Field.check_pick_even();
                        switch (choice)
                        {
                            case 0:
                                while (Field.check_x_o(randomI, randomJ) != -1 || randomI == 0 && randomJ == 0 || (randomI + randomJ) % 2 != 0)
                                {
                                    randomI = random.Next(0, 3);
                                    randomJ = random.Next(0, 3);
                                }
                                return randomI * 3 + randomJ;
                            case 2:
                                while (Field.check_x_o(randomI, randomJ) != -1 || randomI == 0 && randomJ == 2 || (randomI + randomJ) % 2 != 0)
                                {
                                    randomI = random.Next(0, 3);
                                    randomJ = random.Next(0, 3);
                                }
                                return randomI * 3 + randomJ;
                            case 6:
                                while (Field.check_x_o(randomI, randomJ) != -1 || randomI == 2 && randomJ == 0 || (randomI + randomJ) % 2 != 0)
                                {
                                    randomI = random.Next(0, 3);
                                    randomJ = random.Next(0, 3);
                                }
                                return randomI * 3 + randomJ;
                            case 8:
                                while (Field.check_x_o(randomI, randomJ) != -1 || randomI == 2 && randomJ == 2 || (randomI + randomJ) % 2 != 0)
                                {
                                    randomI = random.Next(0, 3);
                                    randomJ = random.Next(0, 3);
                                }
                                return randomI * 3 + randomJ;

                        }
                    }

                }
                
                if (countMove >= 4)
                {
                    while (Field.check_x_o(randomI, randomJ) != -1)
                    {
                        randomI = random.Next(0, 3);
                        randomJ = random.Next(0, 3);
                    }
                }
                else
                {
                    while (Field.check_x_o(randomI, randomJ) != -1 || (randomI + randomJ) % 2 != 0)
                    {
                        randomI = random.Next(0, 3);
                        randomJ = random.Next(0, 3);
                    }
                }

            }
            

            Field.put_x_o(randomI, randomJ, is_tic);
            
            return randomI * 3 + randomJ;
        }
    }
}
