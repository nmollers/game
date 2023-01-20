using System;
using System.Windows.Forms;

class TicTacToeForm : Form {
    private const int formSize = 300;
    private const int buttonSize = 100;
    private const int buttonGap = 5;
    private Button[] buttons;
    private int player;

    public TicTacToeForm() {
        buttons = new Button[9];
        player = 1;
        for (int i = 0; i < 9; i++) {
            buttons[i] = new Button();
            buttons[i].Size = new System.Drawing.Size(buttonSize, buttonSize);
            buttons[i].Location = new System.Drawing.Point((i % 3) * (buttonSize + buttonGap), (i / 3) * (buttonSize + buttonGap));
            buttons[i].Click += new EventHandler(Button_Click);
            this.Controls.Add(buttons[i]);
        }
        this.Text = "Tic-Tac-Toe";
        this.Size = new System.Drawing.Size(formSize, formSize);
    }

    private void Button_Click(object sender, EventArgs e) {
        Button button = (Button)sender;
        if (button.Text == "") {
            if (player % 2 == 0) {
                button.Text = "O";
                player++;
            } else {
                button.Text = "X";
                player++;
            }
        }
        if (Win()) {
            if (player % 2 == 0) {
                MessageBox.Show("Player 1 wins!");
            } else {
                MessageBox.Show("Player 2 wins!");
            }
            Close();
        }
        if (Draw()) {
            MessageBox.Show("It's a draw!");
            Close();
        }
    }

    private bool Win() {
        if ((buttons[0].Text == buttons[1].Text && buttons[1].Text == buttons[2].Text && buttons[0].Text != "") ||
            (buttons[3].Text == buttons[4].Text && buttons[4].Text == buttons[5].Text && buttons[3].Text != "") ||
            (buttons[6].Text == buttons[7].Text && buttons[7].Text == buttons[8].Text && buttons[6].Text != "") ||
            (buttons[0].Text == buttons[3].Text && buttons[3].Text == buttons[6].Text && buttons[0].Text != "") ||
            (buttons[1].Text == buttons[4].Text && buttons[4].Text == buttons[7].Text && buttons[1].Text != "") ||
            (buttons[2].Text == buttons[5].Text && buttons[5].Text == buttons[8].Text && buttons[2].Text != "") ||
            (buttons[0].Text == buttons[4].Text && buttons[4].Text == buttons[8].Text && buttons[0].Text != "") ||
            (buttons[2].Text == buttons[4].Text && buttons[4].Text == buttons[6].Text && buttons[2].Text != ""))
    }