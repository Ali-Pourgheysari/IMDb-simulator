using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    public class ImdbAkas
    {
        public string TitleId { get; set; }
        public int Ordering { get; set; }
        public string Title { get; set; }
        public string Region { get; set; }
        public string Language { get; set; }
        public string Types { get; set; }
        public string Attributes { get; set; }
        public int IsOriginalTitle { get; set; }
    }

    public class ImdbRatings
    {
        //Title id
        public string Tconst { get; set; }
        public decimal AverageRating { get; set; }
        public long NumVotes { get; set; }
        public bool HasVoted { get; set; }
    }
}
