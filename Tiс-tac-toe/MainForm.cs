using System.Runtime.CompilerServices;
using ClassLibraryLogic;

namespace Tiс_tac_toe
{
    public partial class TicTacToe : Form
    {
        private static bool tic = true;
        private static Button[] buttons;
        private static bool[] enableButtons = new bool[9] { true, true, true, true, true, true, true, true, true };
        private static bool isEndGame = false;
        private static int gameMod;
        private static bool botChoice = false;
        private static int theme = 1;

        public TicTacToe()
        {
            InitializeComponent();
            buttons = new Button[9];
            buttons[0] = button1;
            buttons[1] = button2;
            buttons[2] = button3;
            buttons[3] = button4;
            buttons[4] = button5;
            buttons[5] = button6;
            buttons[6] = button7;
            buttons[7] = button8;
            buttons[8] = button9;
        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            if (theme == 0) buttonWhiteTheme_Click(sender, e);
            if (theme == 1) buttonBlackTheme_Click(sender, e);
            this.Size = new Size(557, 525);
            tableLayoutPanelMenu.Location = tableLayoutPanelButtons.Location;
            tableLayoutPanelEndGame.Location = tableLayoutPanelButtons.Location;
            tableLayoutPanelChoiseXO.Location = tableLayoutPanelButtons.Location;

            tableLayoutPanelMenu.Size = tableLayoutPanelButtons.Size;
            tableLayoutPanelEndGame.Size = tableLayoutPanelButtons.Size;
            tableLayoutPanelChoiseXO.Size = tableLayoutPanelButtons.Size;

            tableLayoutPanelButtons.Visible = false;
            tableLayoutPanelEndGame.Visible = false;
            tableLayoutPanelChoiseXO.Visible = false;
            tableLayoutPanelMenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelEndGame.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelButtons.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanelChoiseXO.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void bot_click(object sender, EventArgs e, int num)
        {
            //бот делает выбор
            botChoice = true;
            switch (num)
            {
                case 0: button1_Click(sender, e); break;
                case 1: button2_Click(sender, e); break;
                case 2: button3_Click(sender, e); break;
                case 3: button4_Click(sender, e); break;
                case 4: button5_Click(sender, e); break;
                case 5: button6_Click(sender, e); break;
                case 6: button7_Click(sender, e); break;
                case 7: button8_Click(sender, e); break;
                case 8: button9_Click(sender, e); break;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //во время просмотра поля вернуться к окончанию игры
            if (isEndGame) tableLayoutPanelEndGame.Visible = true;
            //проверка на уже нажатую кнопку
            if (!enableButtons[0]) return;
            //нажимаем кнопку
            enableButtons[0] = false;
            //вставляем X или O
            button1.Text = tic ? "X" : "O";
            //меняем цвет в зависимости от хода
            button1.ForeColor = tic ? Color.Red : Color.Blue;
            //вставляем в массив ход
            ClassLibraryLogic.Field.put_x_o(0, 0, tic);
            //меняем ход
            tic = !tic;
            //вывод чей сейчас ход
            this.Text = tic ? "Ход крестиков" : "Ход ноликов";
            //проверка на то чтобы бот не нажимал кнопку после окончании игры
            if (check_WLD()) return;
            //если режим не одиночный и бот делает выбор
            if (gameMod != 0 && !botChoice)
            {
                //бот делает ход
                bot_click(sender, e, bot_move(gameMod));
                //бот теперь не может сделать ход
                botChoice = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isEndGame) tableLayoutPanelEndGame.Visible = true;
            if (!enableButtons[1]) return;
            enableButtons[1] = false;
            button2.Text = tic ? "X" : "O";
            button2.ForeColor = tic ? Color.Red : Color.Blue;
            ClassLibraryLogic.Field.put_x_o(0, 1, tic);
            tic = !tic;
            this.Text = tic ? "Ход крестиков" : "Ход ноликов";
            if (check_WLD()) return;
            if (gameMod != 0 && !botChoice)
            {
                bot_click(sender, e, bot_move(gameMod));
                botChoice = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isEndGame) tableLayoutPanelEndGame.Visible = true;
            if (!enableButtons[2]) return;
            enableButtons[2] = false;
            button3.Text = tic ? "X" : "O";
            button3.ForeColor = tic ? Color.Red : Color.Blue;
            ClassLibraryLogic.Field.put_x_o(0, 2, tic);
            tic = !tic;
            this.Text = tic ? "Ход крестиков" : "Ход ноликов";
            if (check_WLD()) return;
            if (gameMod != 0 && !botChoice)
            {
                bot_click(sender, e, bot_move(gameMod));
                botChoice = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isEndGame) tableLayoutPanelEndGame.Visible = true;
            if (!enableButtons[3]) return;
            enableButtons[3] = false;
            button4.Text = tic ? "X" : "O";
            button4.ForeColor = tic ? Color.Red : Color.Blue;
            ClassLibraryLogic.Field.put_x_o(1, 0, tic);
            tic = !tic;
            this.Text = tic ? "Ход крестиков" : "Ход ноликов";
            if (check_WLD()) return;
            if (gameMod != 0 && !botChoice)
            {
                bot_click(sender, e, bot_move(gameMod));
                botChoice = false;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isEndGame) tableLayoutPanelEndGame.Visible = true;
            if (!enableButtons[4]) return;
            enableButtons[4] = false;
            button5.Text = tic ? "X" : "O";
            button5.ForeColor = tic ? Color.Red : Color.Blue;
            ClassLibraryLogic.Field.put_x_o(1, 1, tic);
            tic = !tic;
            this.Text = tic ? "Ход крестиков" : "Ход ноликов";
            if (check_WLD()) return;
            if (gameMod != 0 && !botChoice)
            {
                bot_click(sender, e, bot_move(gameMod));
                botChoice = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (isEndGame) tableLayoutPanelEndGame.Visible = true;
            if (!enableButtons[5]) return;
            enableButtons[5] = false;
            button6.Text = tic ? "X" : "O";
            button6.ForeColor = tic ? Color.Red : Color.Blue;
            ClassLibraryLogic.Field.put_x_o(1, 2, tic);
            tic = !tic;
            this.Text = tic ? "Ход крестиков" : "Ход ноликов";
            if (check_WLD()) return;
            if (gameMod != 0 && !botChoice)
            {
                bot_click(sender, e, bot_move(gameMod));
                botChoice = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (isEndGame) tableLayoutPanelEndGame.Visible = true;
            if (!enableButtons[6]) return;
            enableButtons[6] = false;
            button7.Text = tic ? "X" : "O";
            button7.ForeColor = tic ? Color.Red : Color.Blue;
            ClassLibraryLogic.Field.put_x_o(2, 0, tic);
            tic = !tic;
            this.Text = tic ? "Ход крестиков" : "Ход ноликов";
            if (check_WLD()) return;
            if (gameMod != 0 && !botChoice)
            {
                bot_click(sender, e, bot_move(gameMod));
                botChoice = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (isEndGame) tableLayoutPanelEndGame.Visible = true;
            if (!enableButtons[7]) return;
            enableButtons[7] = false;
            button8.Text = tic ? "X" : "O";
            button8.ForeColor = tic ? Color.Red : Color.Blue;
            ClassLibraryLogic.Field.put_x_o(2, 1, tic);
            tic = !tic;
            this.Text = tic ? "Ход крестиков" : "Ход ноликов";
            if (check_WLD()) return;
            if (gameMod != 0 && !botChoice)
            {
                bot_click(sender, e, bot_move(gameMod));
                botChoice = false;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (isEndGame) tableLayoutPanelEndGame.Visible = true;
            if (!enableButtons[8]) return;
            enableButtons[8] = false;
            button9.Text = tic ? "X" : "O";
            button9.ForeColor = tic ? Color.Red : Color.Blue;
            ClassLibraryLogic.Field.put_x_o(2, 2, tic);
            tic = !tic;
            this.Text = tic ? "Ход крестиков" : "Ход ноликов";
            if (check_WLD()) return;
            if (gameMod != 0 && !botChoice)
            {
                bot_click(sender, e, bot_move(gameMod));
                botChoice = false;
            }
        }
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            tableLayoutPanelEndGame.Visible = false;
            tableLayoutPanelButtons.Visible = false;
            tableLayoutPanelMenu.Visible = true;
            //очищаем поле
            ClassLibraryLogic.Field.clear_field();
            //восстанавливаем ход крестиков
            tic = true;
            //включаем кнопки с выбором режима игры
            buttonTwoGame.Enabled = true;
            buttonEasyBot.Enabled = true;
            buttonMediumBot.Enabled = true;
            buttonImpossibleBot.Enabled = true;
            //сбрасываем счетчик ходов
            Bots_mod.reset_count_move();
            //тему
            if (theme == 0) buttonWhiteTheme_Click(sender, e);
            if (theme == 1) buttonBlackTheme_Click(sender, e);
        }

        private void buttonSoloGame_Click(object sender, EventArgs e)
        {
            gameMod = 0;
            isEndGame = false;
            //очищаем кнопки
            empty_text_buttons();
            //включаем кнопки
            enabled_buttons(true);
            tableLayoutPanelMenu.Visible = false;
            tableLayoutPanelButtons.Visible = true;
            this.Text = "Ход крестиков";

        }
        public void enabled_buttons(bool enabled) { for (int i = 0; i < 9; ++i) enableButtons[i] = enabled; }
        public void empty_text_buttons() { foreach (Button button in buttons) button.Text = ""; }
        public bool check_WLD()
        {
            Field field = new Field();
            int WLD = field.check_field(Field.field);
            
            if (WLD != -1)
            {
                switch (WLD)
                {
                    case 0:
                        labelWLD.Text = "Нолики победили";
                        labelWLD.ForeColor = Color.Blue;
                        break;
                    case 1:
                        labelWLD.Text = "Крестики победили";
                        labelWLD.ForeColor = Color.Red;
                        break;
                    case 2:
                        labelWLD.Text = "Ничья";
                        break;
                }
                enabled_buttons(false);
                tableLayoutPanelEndGame.Visible = true;
                this.Text = "Крестики нолики";
                isEndGame = true;
            }
            return isEndGame;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonViewField_Click(object sender, EventArgs e)
        {
            tableLayoutPanelEndGame.Visible = false;
        }

        private void buttonEasyBot_Click(object sender, EventArgs e)
        {
            //показываем панель с выбором стороны
            tableLayoutPanelChoiseXO.Visible = true;
            //меняем цвет надписи выбора стороны и кнопки посмотреть поле
            labelXO.ForeColor = Color.Green;
            //buttonViewField.ForeColor = Color.Green;
            //выключаем кнопки с выбором режима игры
            buttonTwoGame.Enabled = false;
            buttonEasyBot.Enabled = false;
            buttonMediumBot.Enabled = false;
            buttonImpossibleBot.Enabled = false;
            //игровой режим
            gameMod = 1;
            //меняем цвет кнопок
            change_color(gameMod, sender, e);
        }
        public static int bot_move(int mode)
        {
            int choice;
            switch (mode)
            {
                case 1:
                    choice = Bots_mod.easy_bot(false);
                    return choice;
                case 2:
                    choice = Bots_mod.medium_bot(tic);
                    return choice;
                case 3:
                    choice = Bots_mod.impossible_bot(tic);
                    return choice;
            }
            return -1;
        }

        private void buttonMediumBot_Click(object sender, EventArgs e)
        {
            //показываем панель с выбором стороны
            tableLayoutPanelChoiseXO.Visible = true;
            //меняем цвет надписи выбора стороны и кнопки посмотреть поле
            labelXO.ForeColor = Color.Yellow;
            //buttonViewField.ForeColor = Color.Yellow;
            //выключаем кнопки с выбором режима игры
            buttonTwoGame.Enabled = false;
            buttonEasyBot.Enabled = false;
            buttonMediumBot.Enabled = false;
            buttonImpossibleBot.Enabled = false;
            //игровой режим
            gameMod = 2;
            //меняем цвет кнопок
            change_color(gameMod, sender, e);
        }


        private void buttonImpossibleBot_Click(object sender, EventArgs e)
        {
            //показываем панель с выбором стороны
            tableLayoutPanelChoiseXO.Visible = true;
            //меняем цвет надписи выбора стороны и кнопки посмотреть поле
            labelXO.ForeColor = Color.Red;
            //buttonViewField.ForeColor = Color.Red;
            //выключаем кнопки с выбором режима игры
            buttonTwoGame.Enabled = false;
            buttonEasyBot.Enabled = false;
            buttonMediumBot.Enabled = false;
            buttonImpossibleBot.Enabled = false;
            //игровой режим
            gameMod = 3;
            //меняем цвет кнопок
            change_color(gameMod, sender, e);
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            //скрываем панель
            tableLayoutPanelChoiseXO.Visible = false;
            isEndGame = false;
            //очищаем кнопки
            empty_text_buttons();
            //включаем кнопки
            enabled_buttons(true);
            tableLayoutPanelMenu.Visible = false;
            tableLayoutPanelButtons.Visible = true;
            this.Text = "Ход крестиков";
        }

        private void buttonO_Click(object sender, EventArgs e)
        {
            //скрываем панель
            tableLayoutPanelChoiseXO.Visible = false;
            isEndGame = false;
            //очищаем кнопки
            empty_text_buttons();
            //включаем кнопки
            enabled_buttons(true);
            tableLayoutPanelMenu.Visible = false;
            tableLayoutPanelButtons.Visible = true;
            this.Text = "Ход крестиков";
            //ход бота
            bot_click(sender, e, bot_move(gameMod));
            botChoice = false;
        }

        private void buttonBlackTheme_Click(object sender, EventArgs e)
        {
            //buttonEasyBot.FlatAppearance.MouseOverBackColor = Color.Gray;
            //buttonEasyBot.FlatAppearance.MouseDownBackColor = Color.White;

            theme = 1;
            this.BackColor = Color.Black;
            //buttonBlackTheme.BackColor = Color.Black;
            //buttonBlackTheme.ForeColor = Color.White;
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.White;
            button4.BackColor = Color.Black;
            button4.ForeColor = Color.White;
            button5.BackColor = Color.Black;
            button5.ForeColor = Color.White;
            button6.BackColor = Color.Black;
            button6.ForeColor = Color.White;
            button7.BackColor = Color.Black;
            button7.ForeColor = Color.White;
            button8.BackColor = Color.Black;
            button8.ForeColor = Color.White;
            button9.BackColor = Color.Black;
            button9.ForeColor = Color.White;
            buttonTwoGame.BackColor = Color.Black;
            //buttonSoloGame.ForeColor = Color.White;
            buttonEasyBot.BackColor = Color.Black;
            //buttonEasyBot.ForeColor = Color.White;
            buttonMediumBot.BackColor = Color.Black;
            //buttonMediumBot.ForeColor = Color.White;
            buttonImpossibleBot.BackColor = Color.Black;
            //buttonImpossibleBot.ForeColor = Color.White;
            buttonContinue.BackColor = Color.Black;
            buttonContinue.ForeColor = Color.White;
            buttonViewField.BackColor = Color.Black;
            buttonViewField.ForeColor = Color.White;
            buttonExit.BackColor = Color.Black;
            buttonExit.ForeColor = Color.White;
            buttonX.BackColor = Color.Black;
            //buttonX.ForeColor = Color.White;
            buttonO.BackColor = Color.Black;
            //buttonO.ForeColor = Color.White;
            labelChoiceGameMode.BackColor = Color.Black;
            labelChoiceGameMode.ForeColor = Color.White;
            labelXO.BackColor = Color.Black;
            labelXO.ForeColor = Color.White;
            labelWLD.BackColor = Color.Black;
            labelWLD.ForeColor = Color.White;
            //buttonWhiteTheme.BackColor = Color.Black;
            //buttonWhiteTheme.ForeColor = Color.White;
        }

        private void buttonWhiteTheme_Click(object sender, EventArgs e)
        {
            //buttonEasyBot.FlatAppearance.MouseOverBackColor = Color.Black;

            theme = 0;
            this.BackColor = Color.White;
            //buttonBlackTheme.BackColor = Color.White;
            //buttonBlackTheme.ForeColor = Color.Black;
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
            button4.BackColor = Color.White;
            button4.ForeColor = Color.Black;
            button5.BackColor = Color.White;
            button5.ForeColor = Color.Black;
            button6.BackColor = Color.White;
            button6.ForeColor = Color.Black;
            button7.BackColor = Color.White;
            button7.ForeColor = Color.Black;
            button8.BackColor = Color.White;
            button8.ForeColor = Color.Black;
            button9.BackColor = Color.White;
            button9.ForeColor = Color.Black;
            buttonTwoGame.BackColor = Color.White;
            //buttonSoloGame.ForeColor = Color.Black;
            buttonEasyBot.BackColor = Color.White;
            //buttonEasyBot.ForeColor = Color.Black;
            buttonMediumBot.BackColor = Color.White;
            //buttonMediumBot.ForeColor = Color.Black;
            buttonImpossibleBot.BackColor = Color.White;
            //buttonImpossibleBot.ForeColor = Color.Black;
            buttonContinue.BackColor = Color.White;
            buttonContinue.ForeColor = Color.Black;
            buttonViewField.BackColor = Color.White;
            buttonViewField.ForeColor = Color.Black;
            buttonExit.BackColor = Color.White;
            buttonExit.ForeColor = Color.Black;
            buttonX.BackColor = Color.White;
            //buttonX.ForeColor = Color.Black;
            buttonO.BackColor = Color.White;
            //buttonO.ForeColor = Color.Black;
            labelChoiceGameMode.BackColor = Color.White;
            labelChoiceGameMode.ForeColor = Color.Black;
            labelXO.BackColor = Color.White;
            labelXO.ForeColor = Color.Black;
            labelWLD.BackColor = Color.White;
            labelWLD.ForeColor = Color.Black;
            //buttonWhiteTheme.BackColor = Color.White;
            //buttonWhiteTheme.ForeColor = Color.Black;
        }

        private void TicTacToe_Resize(object sender, EventArgs e)
        {
            int bordersize = (Math.Min(this.Size.Width, this.Size.Height) - 250) / 50;
            buttonTwoGame.FlatAppearance.BorderSize = bordersize;
            buttonEasyBot.FlatAppearance.BorderSize = bordersize;
            buttonMediumBot.FlatAppearance.BorderSize= bordersize;
            buttonImpossibleBot.FlatAppearance.BorderSize = bordersize;

            buttonWhiteTheme.FlatAppearance.BorderSize = bordersize; 
            buttonBlackTheme.FlatAppearance.BorderSize = bordersize;

            button1.FlatAppearance.BorderSize = bordersize;
            button2.FlatAppearance.BorderSize = bordersize;
            button3.FlatAppearance.BorderSize = bordersize;
            button4.FlatAppearance.BorderSize = bordersize;
            button5.FlatAppearance.BorderSize = bordersize;
            button6.FlatAppearance.BorderSize = bordersize;
            button7.FlatAppearance.BorderSize = bordersize;
            button8.FlatAppearance.BorderSize = bordersize;
            button9.FlatAppearance.BorderSize = bordersize;

            buttonX.FlatAppearance.BorderSize = bordersize;
            buttonO.FlatAppearance.BorderSize = bordersize;

            buttonContinue.FlatAppearance.BorderSize = bordersize;
            buttonViewField.FlatAppearance.BorderSize = bordersize;
            buttonExit.FlatAppearance.BorderSize = bordersize;

            //this.Size = new Size(557, 525);
            //float buttons_divide_w = ((float)557 / 72);
            //float buttons_divide_h = ((float)525 / 72);
            float form_w = (float)this.Size.Width;
            float form_h = (float)this.Size.Height;
            Font font_buttons = new Font("Segoe UI", Math.Min(form_w / ((float)557 / 72), form_h / ((float)525 / 72)), FontStyle.Bold);

            Font font_theme_buttons = new Font("Segoe UI", Math.Min(form_w / ((float)557 / (float)11.25), form_h / ((float)525 / (float)11.25)), FontStyle.Bold);
            Font font_gameMode = new Font("Segoe UI", Math.Min(form_w / ((float)557 / (float)20.25), form_h / ((float)525 / (float)20.25)), FontStyle.Bold);
            Font font_labels = new Font("Segoe UI", Math.Min(form_w / ((float)557 / (float)21.75), form_h / ((float)525 / (float)21.75)), FontStyle.Bold);
            Font font_three_buttons = new Font("Segoe UI", Math.Min(form_w / ((float)557 / (float)15.75), form_h / ((float)525 / (float)15.75)), FontStyle.Bold);
            //this.Text = Math.Min(form_w, form_h).ToString();
            button1.Font = font_buttons;
            button2.Font = font_buttons;
            button3.Font = font_buttons;
            button4.Font = font_buttons;
            button5.Font = font_buttons;
            button6.Font = font_buttons;
            button7.Font = font_buttons;
            button8.Font = font_buttons;
            button9.Font = font_buttons;
            buttonX.Font = font_buttons;
            buttonO.Font = font_buttons;

            buttonWhiteTheme.Font = font_theme_buttons;
            buttonBlackTheme.Font = font_theme_buttons;

            buttonTwoGame.Font = font_gameMode;
            buttonEasyBot.Font = font_gameMode;
            buttonMediumBot.Font = font_gameMode;
            buttonImpossibleBot.Font = font_gameMode;

            labelChoiceGameMode.Font = font_labels;
            labelXO.Font = font_labels;
            labelWLD.Font = font_labels;

            buttonContinue.Font = font_three_buttons;
            buttonViewField.Font = font_three_buttons;
            buttonExit.Font = font_three_buttons;
        }
        private void change_color(int gameMode, object sender, EventArgs e)
            {
            switch (gameMode)
            {
                case 1:
                    button1.ForeColor = Color.Green;
                    button2.ForeColor = Color.Green;
                    button3.ForeColor = Color.Green;
                    button4.ForeColor = Color.Green;
                    button5.ForeColor = Color.Green;
                    button6.ForeColor = Color.Green;
                    button7.ForeColor = Color.Green;
                    button8.ForeColor = Color.Green;
                    button9.ForeColor = Color.Green;
                    break;
                case 2:
                    button1.ForeColor = Color.Yellow;
                    button2.ForeColor = Color.Yellow;
                    button3.ForeColor = Color.Yellow;
                    button4.ForeColor = Color.Yellow;
                    button5.ForeColor = Color.Yellow;
                    button6.ForeColor = Color.Yellow;
                    button7.ForeColor = Color.Yellow;
                    button8.ForeColor = Color.Yellow;
                    button9.ForeColor = Color.Yellow;
                    break;
                case 3:
                    button1.ForeColor = Color.Red;
                    button2.ForeColor = Color.Red;
                    button3.ForeColor = Color.Red;
                    button4.ForeColor = Color.Red;
                    button5.ForeColor = Color.Red;
                    button6.ForeColor = Color.Red;
                    button7.ForeColor = Color.Red;
                    button8.ForeColor = Color.Red;
                    button9.ForeColor = Color.Red;
                    break;
            }
        }
    }
}
