using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MysterArtBank_End.Models
{
    public class Image
    {
        public int ImageID { get; set; }
        public String Link { get; set; }
        public Colection Colection { get; set; }

        public Image()
        {

        }

        public Image(int imageid, string link, Colection colection)
        {
            this.ImageID = imageid;
            this.Link = link;
            this.Colection = colection;
        }




    }
}