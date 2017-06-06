namespace mvc_tutorial_restart.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Albums")]
    public partial class Album1
    {
        [Key]
        public int AlbumID { get; set; }

        public string Title { get; set; }

        public int GenreID { get; set; }

        public int ArtistID { get; set; }

        public decimal Price { get; set; }

        public string AlbumArtUrl { get; set; }

        public virtual Artist1 Artist { get; set; }

        public virtual Genre1 Genre { get; set; }
    }
}
