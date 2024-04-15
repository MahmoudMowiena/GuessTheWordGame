using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class CreateRoom : Form
    {
        Client client;
        RoomForm roomForm;
        public CreateRoom()
        {
            InitializeComponent();
            client = Client.ClientInstance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string response = "";

            if (radioButton1.Checked)
                response = radioButton1.Text;

            else if (radioButton2.Checked)
                response = radioButton2.Text;

            else if (radioButton3.Checked)
                response = radioButton3.Text;

            string message = String.Concat("Create:", response);
            client.SendMsg(message);

            this.Close();
        }
    }
}
