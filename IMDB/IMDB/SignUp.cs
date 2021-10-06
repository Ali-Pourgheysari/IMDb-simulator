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
    public partial class SignUp : Form
    {

        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != "" || txtUser.Text != "")
            {
                if (Form1.UserList.FirstOrDefault(u => u.Username == txtUser.Text) == null)
                {
                    Form1.UserList.Add(new User() { Username = txtUser.Text, Password = txtPass.Text });
                    MessageBox.Show("You have been registered succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("This user has already been registered! Please choose another Username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }



}

