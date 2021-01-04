using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MysterArtBank_End.Models
{
    public class Service
    {
        public int ServiceID { get; set; }
        public String Name { get; set; }
        public String LinkAvartar { get; set; }

        public List<Colection> listColection { get; set; }    


        public Service(int serviceID , String name, String linkAvatar)
        {
            this.ServiceID = serviceID;
            this.Name = name;
            this.LinkAvartar = linkAvatar;
        }
        public Service()
        {
                
        }

    }
}