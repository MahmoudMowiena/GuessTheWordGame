using System.Threading;

namespace project1
{
    public partial class Home : Form
    {
        Register RegisterForm;
        public Home()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            RegisterForm = new Register();
            RegisterForm.Show();
            this.Hide();
        }
    }
}
