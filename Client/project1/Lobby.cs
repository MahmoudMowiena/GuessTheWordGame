using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class Lobby : Form
    {
        Client client;
        Room room;
        CreateRoom createRoom;
        RoomForm roomForm;

        List<string> RoomsKey;
        List<string> RoomsValue;

        public Button JoinButton
        {
            get
            { return Join_btn; }
            set
            { Join_btn = value; }
        }

        public Button WatchButton
        {
            get
            { return W_Btn; }
            set
            { W_Btn = value; }
        }

        public static Lobby lobbyRetriever;

        public Lobby()
        {
            InitializeComponent();
            client = Client.ClientInstance;

            RoomsKey = new List<string>();
            RoomsValue = new List<string>();

            lobbyRetriever = this;
        }

        private void Create_btn_Click(object sender, EventArgs e)
        {
            createRoom = new CreateRoom();
            createRoom.ShowDialog(this);
        }

        private void Join_btn_Click(object sender, EventArgs e)
        {
            string roomID = RoomsKey[listBox1.SelectedIndex];
            string message = String.Concat("JoinRequest:", roomID);

            client.SendMsg(message);
        }

        private void Watch_btn_Click(object sender, EventArgs e)
        {
            string roomID = RoomsKey[listBox1.SelectedIndex];
            string message = String.Concat("Watch:", roomID);
            client.SendMsg(message);
        }

        public void ClientMsgReceived(Client client, string message)
        {
            string[] msgArray = message.Split(':');

            switch (msgArray[0])
            {
                case "ShowRooms": //lobby -> ok
                    ShowRooms(msgArray);
                    break;

                case "JoinRequest": //room -> ok
                    roomForm.JoinRequest(msgArray);
                    break;

                case "JoinApproved": //lobby -> ok
                    JoinRequestApproved(msgArray);
                    break;

                case "JoinDenied": //lobby -> ok
                    JoinRequestDenied();
                    break;

                case "RoomCreated": //lobby -> ok
                    RoomCreated(msgArray);
                    break;

                case "PlayerJoined": //room -> ok
                    roomForm.PlayerJoined(msgArray);
                    break;

                case "LetterPressed": //room -> ok
                    roomForm.LetterPressed(msgArray);
                    break;

                case "WatchRoom":
                    WatchRoom(msgArray);
                    break;

                case "SetText":
                    roomForm.SetText(msgArray);
                    break;

                case "PlayAgainDenied":
                    roomForm.PlayAgainDenied();
                    break;

                case "PlayAgainAccepted":
                    roomForm.PlayAgainAccepted(msgArray);
                    break;

                case "PlayerLeft":
                    roomForm.PlayerLeft();
                    break;
            }
        }

        private void ShowRooms(string[] msgArray)
        {
            int roomCounter = 0;
            listBox1.Invoke(() => { listBox1.Items.Clear(); });
            RoomsKey.Clear();
            RoomsValue.Clear();
            for (int i = 1; i < msgArray.Length; i++)
            {
                string[] roomDataSplitter = msgArray[i].Split("|");
                string roomData = "";

                if (roomDataSplitter.Length == 3)
                    roomData = $"Room{++roomCounter}  Players:{roomDataSplitter[1]}  P1:{roomDataSplitter[2]}";
                else if (roomDataSplitter.Length == 4)
                    roomData = $"Room{++roomCounter}  Players:{roomDataSplitter[1]}  P1:{roomDataSplitter[2]}  P2:{roomDataSplitter[3]}";

                RoomsValue.Add(roomData);
                RoomsKey.Add(roomDataSplitter[0]);
                listBox1.Invoke(() => { listBox1.Items.Add(roomData); });
            }
        }

        private void JoinRequestApproved(string[] msgArray)
        {
            client = Client.ClientInstance;
            room = new Room(new Client(msgArray[2]), client, msgArray[1], msgArray[3]);
            Room.RoomInstance = room;
            roomForm = new RoomForm();
            string player1UserName = msgArray[4];
            Invoke(() => { roomForm.Player1LabelText = player1UserName; });
            this.Invoke(() => { roomForm.Show(); });
            this.Invoke(() => { this.Hide(); });
        }

        private void JoinRequestDenied()
        {
            this.Invoke(() => { MessageBox.Show("Player declined your request!"); });
        }

        private void RoomCreated(string[] msgArray)
        {
            client = Client.ClientInstance;
            room = new Room(client, msgArray[1]);
            Room.RoomInstance = room;
            roomForm = new RoomForm();
            this.Invoke(() => { roomForm.Show(); });
            this.Invoke(() => { this.Hide(); });
        }

        private void WatchRoom(string[] msgArray)
        {
            string roomID = msgArray[1];
            Client player1 = new Client(msgArray[2]);
            if (msgArray.Length == 4)
            {
                Client player2 = new Client(msgArray[3]);
                string guessedWord = msgArray[4];
                room = new Room(player1, player2, roomID, guessedWord);
            }
            else
                room = new Room(player1, roomID);
            Room.RoomInstance = room;
            roomForm = new RoomForm();
            this.Invoke(() => { roomForm.Show(); });
            this.Invoke(() => { this.Hide(); }); //close
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                Join_btn.Enabled = false;
                W_Btn.Enabled = false;
            }
            else
            {
                W_Btn.Enabled = true;

                if (listBox1.Text.Contains("Players:1"))
                    Join_btn.Enabled = true;
            }
        }

        private void Lobby_FormClosing(object sender, FormClosingEventArgs e)
        {
            string dialogMessage = "Are you sure you want to exit game?";

            DialogResult response = MessageBox.Show(dialogMessage, "Exit game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                client.SendMsg("LobbyClosing");
                client.CloseConnections();
            }
            else if (response == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            string dialogMessage = "Are you sure you want to exit game?";

            DialogResult response = MessageBox.Show(dialogMessage, "Exit game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (response == DialogResult.Yes)
            {
                client.SendMsg("LobbyClosing");
                client.CloseConnections();
            }
        }
    }
}
