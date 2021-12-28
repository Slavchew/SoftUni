using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFDemo.Models
{
    public partial class Sources
    {
        public Sources()
        {
            ArtistMetadata = new HashSet<ArtistMetadata>();
            SongMetadata = new HashSet<SongMetadata>();
            Songs = new HashSet<Songs>();
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }

        [InverseProperty("Source")]
        public virtual ICollection<ArtistMetadata> ArtistMetadata { get; set; }
        [InverseProperty("Source")]
        public virtual ICollection<SongMetadata> SongMetadata { get; set; }
        [InverseProperty("Source")]
        public virtual ICollection<Songs> Songs { get; set; }
    }
}
