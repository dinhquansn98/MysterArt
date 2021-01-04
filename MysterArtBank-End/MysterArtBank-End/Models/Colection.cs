using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MysterArtBank_End.Models
{
    public class Colection
    {
        public int ColectionID { get; set; }
        public String Name { get; set; }
        public Service Service { get; set; }
        public String LinkAvartar { get; set; }

        public List<Image> listImage { get; set; }

        public List<Video> listVideo { get; set; }


        public Colection(int colectionID, String name,String linkAvatar)
        {
            this.ColectionID = colectionID;
            this.Name = name;
            this.LinkAvartar = linkAvatar;
        }
        public Colection()
        {

        }

    }
}