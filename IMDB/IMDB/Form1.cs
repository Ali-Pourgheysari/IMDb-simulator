using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMDB
{
    public partial class Form1 : Form
    {
        public static List<User> UserList;

        public Form1()
        {
            InitializeComponent();
            UserList = new List<User>();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login form = new Login();
            form.ShowDialog();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp form = new SignUp();
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
