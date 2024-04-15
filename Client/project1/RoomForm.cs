using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
using static System.Net.Mime.MediaTypeNames;

namespace project1
{
    public partial class RoomForm : Form
    {
        Client client;
        Room room;
        Game game;
        string player;
        bool flag;
        List<string> usedCharacters;
        Button[] buttons;
        Lobby lobby;

        public string Player1LabelText
        {
            get { return player1Name.Text; }
            set { player1Name.Text = value; }
        }

        public RoomForm()
        {
            InitializeComponent();
            client = Client.ClientInstance;
            room = Room.RoomInstance;
            flag = true;
            usedCharacters = new List<string>();
            lobby = Lobby.lobbyRetriever;

            buttons = [A_btn,
                B_btn,
                C_btn,
                D_btn,
                E_btn,
                F_btn,
                G_btn,
                H_btn,
                I_btn,
                J_btn,
                K_btn,
                L_btn,
                M_btn,
                N_btn,
                O_btn,
                P_btn,
                Q_btn,
                R_btn,
                S_btn,
                T_btn,
                U_btn,
                V_btn,
                W_btn,
                X_btn,
                Y_btn,
                Z_btn];

            foreach (Button button in buttons)
            {
                button.Enabled = false;
            }

            if (client.ClientID == room.Player1.ClientID)
            {
                player = "player1";
                player1Name.Text = client.UserName;
                player2Name.ForeColor = Color.Gray;
                if (room.Player2 == null)
                    MessageBox.Show("Please wait for another player to join!");
            }

            else
            {
                if (room.Player2 != null)
                {
                    game = room.GameProperty;
                    if (client.ClientID == room.Player2.ClientID)
                    {
                        player = "player2";
                        label1.Text = game.GuessedWord;
                        player2Name.Text = client.UserName;
                        player2Name.ForeColor = Color.Gray;
                    }
                    else
                    {
                        player = "spectator";
                        Invoke(() => label1.Text = game.GuessedWord); //------->
                    }
                }
                else
                {
                    player = "spectator";
                }
            }
        }

        public void LetterPressed(string[] msgArray)
        {
            string letter, updatedWord, playerOnTurn, isGameEnded;

            letter = msgArray[1];
            updatedWord = msgArray[2];
            playerOnTurn = msgArray[3];
            isGameEnded = msgArray[4];

            Invoke(() => label1.Text = updatedWord);
            usedCharacters.Add(letter);

            if (isGameEnded == "True")
            {
                EndGame(playerOnTurn);
            }
            else
            {
                if (player == playerOnTurn)
                {
                    EnableButtons();
                }
                else
                {
                    DisableButtons();
                }

                if(playerOnTurn == "player1")
                {
                    player1Name.ForeColor = Color.Black;
                    player2Name.ForeColor = Color.Gray;
                }
                else
                {
                    player2Name.ForeColor = Color.Black;
                    player1Name.ForeColor = Color.Gray;
                }
            }
        }

        private void Q_btn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string guessedLetter = button.Text;
            button.Enabled = false;

            string message = $"LetterPressed:{room.RoomID}:{guessedLetter}";
            client.SendMsg(message);
        }

        private void EnableButtons()
        {
            foreach (Button button in buttons)
            {
                if (usedCharacters.Contains(button.Text))
                    this.Invoke(() => { button.Enabled = false; });
                else
                    this.Invoke(() => { button.Enabled = true; });
            }
        }

        private void DisableButtons()
        {
            foreach (Button button in buttons)
            {
                this.Invoke(() => { button.Enabled = false; });
            }
        }

        private void FillLabelBox(string text)
        {
            Invoke(() => label1.Text = text);
        }

        public void JoinRequest(string[] msgArray)
        {
            string dialogMessage = "There is another player who would like to join you, do you accept that?";
            string message;

            DialogResult res = MessageBox.Show(dialogMessage, "request to join", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            {
                message = $"JoinApproved:{room.RoomID}:{msgArray[1]}";
                client.SendMsg(message);
            }
            else if (res == DialogResult.No)
            {
                message = $"JoinDenied:{room.RoomID}:{msgArray[1]}";
                client.SendMsg(message);
            }
        }


        private void EndGame(string playerOnTurn) //we still have work to do here
        {
            string dialogMessage = "";
            if (player == "spectator")
                dialogMessage = $"{playerOnTurn} won!\nWould you like to continue watching?";
            else if (player == playerOnTurn)
                dialogMessage = $"Congratulations, You won!\nWould you like to play again?";
            else
                dialogMessage = $"Game over, You lost :(\nWould you like to play again?";

            DialogResult playAgainRes = Invoke(() => MessageBox.Show(dialogMessage, "game over", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (playAgainRes == DialogResult.No)
            {
                if (player == "spectator")
                {
                    string message = $"ExitWatching:{room.RoomID}";
                    client.SendMsg(message);
                    GoLobby();
                }
                else
                {
                    string message = $"ExitPlaying:{room.RoomID}";
                    client.SendMsg(message);
                    GoLobby();
                }
            }
            else if (playAgainRes == DialogResult.Yes)
            {
                PlayAgainRequested();
                if (player == "player1" || player == "player2")
                {
                    string message = $"PlayAgain:{room.RoomID}";
                    client.SendMsg(message);
                }
            }
        }

        public void PlayerJoined(string[] msgArray)
        {
            room.AddPlayer(new Client(msgArray[1]), msgArray[2]);
            Room.RoomInstance = room;
            game = room.GameProperty;
            string player2UserName = msgArray[3];
            Invoke((Delegate)(() => { player2Name.Text = player2UserName; }));
            FillLabelBox(game.GuessedWord);

            foreach (Button button in buttons)
            {
                this.Invoke(() => { button.Enabled = true; });
            }
        }

        public void SetText(string[] msgArray)
        {
            string text = msgArray[1];
            FillLabelBox(text);
        }

        public void PlayAgainDenied()
        {
            GoLobby();
            client.SendMsg("GetRooms");
        }

        private void PlayAgainRequested()
        {
            Invoke(() => { label1.Text = ""; });
            DisableButtons();
        }

        public void PlayAgainAccepted(string[] msgArray)
        {
            string guessedWord = msgArray[1];
            Invoke(() => { label1.Text = guessedWord; });
            usedCharacters.Clear();
            if (player == "player1")
                EnableButtons();
        }

        public void PlayerLeft()
        {
            DisableButtons();
            Invoke(() => { label1.Text = ""; });
            Invoke(() => { player2Name.Text = "Player 2"; });
            Invoke(() => { MessageBox.Show("Player 2 left, please wait for another player to join!"); });
        }

        private void GoLobby()
        {
            lobby.JoinButton.Enabled = false;
            lobby.WatchButton.Enabled = false;
            Invoke(() => { lobby.Show(); });
            Invoke(() => { this.Hide(); });
        }

        private void RoomForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string dialogMessage = "Are you sure you want to exit game?";
            DialogResult response = MessageBox.Show(dialogMessage, "Exit game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                string message = $"RoomClosing:{room.RoomID}:{player}";
                client.SendMsg(message);
                client.CloseConnections();
            }
            else if (response == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void ExitRoom_btn_Click(object sender, EventArgs e)
        {
            string dialogMessage = "Are you sure you want to exit room?";
            DialogResult response = MessageBox.Show(dialogMessage, "Exit room", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                if (player == "spectator")
                {
                    string message = $"ExitWatching:{room.RoomID}";
                    client.SendMsg(message);
                    GoLobby();
                }
                else
                {
                    string message = $"ExitPlaying:{room.RoomID}";
                    client.SendMsg(message);
                    GoLobby();
                }
            }
        }
    }
}
