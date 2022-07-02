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
    public partial class TopTen : Form
    {
        ReadData data = new ReadData();

        public TopTen()
        {
            InitializeComponent();
            
        }

        private void TopTen_Load(object sender, EventArgs e)
        {
            var innerjoin = (from a in data.AkasDataList
                           join r in data.RatingsDataList on a.TitleId equals r.Tconst
                           orderby r.AverageRating descending 
                           select new
                           {
                               a.Title,
                               r.AverageRating
                           }).Take(10);
            dataGridView1.DataSource = innerjoin.ToList();
            for (int i = 0; i < 10; i++)
            {
                dataGridView1[0,i].Value = i + 1;
            }
        }
    }
}
