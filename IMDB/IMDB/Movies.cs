using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMDB
{
    public partial class Movies : Form
    {

        ReadData data = new ReadData();
        public Movies()
        {
            InitializeComponent();
           
           
        }

        private void Movies_Load(object sender, EventArgs e)
        {
            update();
        }

        void update()
        {
            dataGridView1.AutoGenerateColumns = false;
            var innerjoin = (from a in data.AkasDataList
                             join r in data.RatingsDataList on a.TitleId equals r.Tconst
                             select new
                             {
                                 a.TitleId,
                                 a.Ordering,
                                 a.Title,
                                 a.Region,
                                 a.Language,
                                 a.Types,
                                 a.Attributes,
                                 a.IsOriginalTitle,
                                 r.AverageRating,
                                 r.NumVotes,
                                 r.HasVoted
                             });
            dataGridView1.DataSource = innerjoin.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if ((bool)dataGridView1.CurrentRow.Cells[10].Value == false)
                {
                    Vote form = new Vote((decimal) dataGridView1.CurrentRow.Cells[8].Value);
                    form.ShowDialog();
                    foreach (var item in data.RatingsDataList)
                    {
                        if (item.Tconst == dataGridView1.CurrentRow.Cells[0].Value.ToString())
                        {
                            item.NumVotes++;
                            item.HasVoted = true;
                            break;
                        }
                    }
                    WriteInTheFile();
                }
                else
                {
                    MessageBox.Show("You have voted for this movie once", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                update();
            }

        }
        void WriteInTheFile()
        {
            string Address = Application.StartupPath.Remove(Application.StartupPath.Length - 19) + "title.ratings.txt";
            using (StreamWriter writer = new StreamWriter(Address, false))
            {
                writer.WriteLine("tconst	averageRating	numVotes");
            }
            using (StreamWriter writer = new StreamWriter(Address, true))
            {
                foreach (var item in data.RatingsDataList)
                {
                    writer.WriteLine($"{item.Tconst}\t{item.AverageRating}\t{item.NumVotes}");
                }
            }
        }
    }
}
