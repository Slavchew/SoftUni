using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFDemo.Models
{
    public partial class SongMetadata
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int SongId { get; set; }
        public short Type { get; set; }
        public string Value { get; set; }
        public int? SourceId { get; set; }
        public string SourceItemId { get; set; }

        [ForeignKey(nameof(SongId))]
        [InverseProperty(nameof(Songs.SongMetadata))]
        public virtual Songs Song { get; set; }
        [ForeignKey(nameof(SourceId))]
        [InverseProperty(nameof(Sources.SongMetadata))]
        public virtual Sources Source { get; set; }
    }
}
