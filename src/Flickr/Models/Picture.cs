using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flickr.Models
{
    [Table("Pictures")]
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public byte[] Img { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public Picture()
        {
        }

        public Picture(Byte[] img)
        {
            Img = img;
        }


        public string getImage()

        {
             //Convert byte data array to string that '<img src=' can read
            var base64File = Convert.ToBase64String(Img);
            return String.Format("data:image/gif;base64,{0}", base64File);
        }

    }
}
