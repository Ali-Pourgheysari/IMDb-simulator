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
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != "" && txtUser.Text != "")
            {
                User CheckUser = Form1.UserList.Find(u => u.Username == txtUser.Text && u.Password == txtPass.Text);
                if (CheckUser != null)
                {
                    MessageBox.Show($"Welcome {CheckUser.Name}", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Movies form = new Movies();
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("This user has not registered yet! Please enter a valid set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
