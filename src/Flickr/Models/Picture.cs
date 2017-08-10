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
        public byte[] img { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
