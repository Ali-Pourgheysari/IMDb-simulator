using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMDB
{
    public class ReadData
    {
        public List<ImdbAkas> AkasDataList = new List<ImdbAkas>();
        public List<ImdbRatings> RatingsDataList = new List<ImdbRatings>();

        public ReadData()
        {
            string DocumentAddress = Application.StartupPath;
            string NewAddress = DocumentAddress.Remove(DocumentAddress.Length - 19);
            string[] akas = File.ReadAllLines(NewAddress + "title.akas.txt");
            string[] ratings = File.ReadAllLines(NewAddress + "title.ratings.txt");



            string[] TempForAddingAkasToList;
            string[] TempForAddingRatingsToList;


            for (int i = 1; i < akas.Length; i++)
            {
                TempForAddingAkasToList = akas[i].Split('\t');
                TempForAddingRatingsToList = ratings[i].Split('\t');
                AkasDataList.Add(new ImdbAkas()
                {
                    TitleId = TempForAddingAkasToList[0],
                    Ordering = int.Parse(TempForAddingAkasToList[1]),
                    Title = TempForAddingAkasToList[2],
                    Region = TempForAddingAkasToList[3],
                    Language = TempForAddingAkasToList[4],
                    Types = TempForAddingAkasToList[5],
                    Attributes = TempForAddingAkasToList[6],
                    IsOriginalTitle = (int.Parse(TempForAddingAkasToList[7]) == 1) ? 1 : 0
                });


                RatingsDataList.Add(new ImdbRatings()
                {
                    Tconst = TempForAddingRatingsToList[0],
                    AverageRating = decimal.Parse(TempForAddingRatingsToList[1], CultureInfo.CurrentCulture),
                    NumVotes = int.Parse(TempForAddingRatingsToList[2]),
                    HasVoted = false
                }) ;
            }
        }




    }
}
