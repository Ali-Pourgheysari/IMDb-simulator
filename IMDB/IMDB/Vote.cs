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
    public partial class Vote : Form
    {
        public decimal average { get; set; }
        public Vote(decimal ave)
        {
            InitializeComponent();
            average = ave;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your vote submitted successfully", "submmition", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private void Vote_Load(object sender, EventArgs e)
        {
            txtAve.Text = average.ToString();
        }
    }
}
