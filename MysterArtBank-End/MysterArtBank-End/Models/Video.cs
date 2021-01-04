using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MysterArtBank_End.Models
{
    public class Video
    {
        public int VideoID { get; set; }
        public String Link { get; set; }
        public Colection Colection { get; set; }


        public Video(int videoID,String link,Colection colection)
        {
            this.VideoID = videoID;
            this.Link = link;
            this.Colection = colection;
                
        }
        
    }
}