using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace project1
{
    public partial class Register : Form
    {
        Client client;
        Lobby lobby;

        public string userName { set; get; }
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username_textbox.Text != "")
            {
                userName = username_textbox.Text;
                try
                {
                    client = new Client();
                    client.ConnectToServer();
                    Client.ClientInstance = client;
                    lobby = new Lobby();
                    lobby.Show();
                    this.Hide();
                    client.MessageReceived += lobby.ClientMsgReceived;
                    client.UserName = userName;
                    string message = $"LobbyAccess:{userName}";
                    client.SendMsg(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("UserName is Required!");
            }
        }
    }
}
